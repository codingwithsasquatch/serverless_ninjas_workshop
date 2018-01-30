# Serverless Logic Apps Demo Setup

Setup:  Create Azure Storage Account, CosmosDB, Azure Search
This must be completed before giving demo.

## Create a Storage Account

The storage account will be used to upload a file to start the Logic App.

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/New_Button.png "New Button")

1. Type "Azure Blob" into the search box and select Azure Blob when it pops up

    ![Azure Storage](images/Storage_Create.png "Azure Storage")

1. On the next blade select Storage Account - blob, file, table, queue

    ![Azure Storage](images/Storage_Results.png "Azure Storage")

1. Then click "Create"

    ![Create](images/Create.png "Create")

1. Give it a name, location, resource group, location, and change the Account kind to "Blob storage".  The click Create.

    ![Create Storage](images/Storage_Values_Create.png "Create Storage")

1. When the deployment finishes, we need to create the blob container in the storage account. Click on the "go to resource" button of the deployment notification

    ![Go to Azure Storage](images/goto_storage.png "Go to Azure Storage")

1. Click the Blobs link in the middle of the screen under Services.

    ![Azure Storage](images/storage_blob.png "Azure Storage")

1. On the Blob Service page, select "+ Container"

    ![Create Storage Container](images/add_container.png "Create Storage Container")

1. On the New Container screen, give the container a name and set the access level.  Then press "OK".

    ![Storage Container](images/new_container.png "Create Storage Container")

1. (Optional) It is recommended that you download and install Azure Storage Explorer from [https://azure.microsoft.com/en-us/features/storage-explorer/](https://azure.microsoft.com/en-us/features/storage-explorer/).

    The demo does use the Azure Storage Explorer, though the file can be uploaded from the portal.

## Create CosmosDB

Now that we have an storage account let's create an instance of CosmosDB where the messages from the file will be saved.

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "Azure Cosmos DB" into the search box and select Azure Cosmos DB when it pops up

    ![Azure Cosmos DB](images/cosmos search.png "Azure Cosmos DB")

1. On the next blade select Azure Cosmos DB

    ![Azure Cosmos DB](images/cosmosdb.png "Azure Cosmos DB")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. Now let's give it a name,  use SQL as the API (since this data is in JSON format already), and use the same existing Resource Group as our Storage Account just to keep everything organized. Then click "Create"

    ![Create Cosmos DB](images/create_cosmosdb.png "Create Cosmos DB")

1. When the deployment finishes, we need to create the DB container. Click on the "go to resource" button of the deployment notification

    ![Go to CosmosDB](images/goto_cosmosdb.png "Go to CosmosDB")

1. When the deployment finishes, we need to create the DB container. Click on the "go to resource" button of the deployment notification

    ![Go to CosmosDB](images/goto_cosmosdb.png "Go to CosmosDB")

1. On the CosmosDB overview page, Click "Add Collection"

    ![Add Collection](images/add_collection.png "Add Collection")

1. In the blade on the right hand side, give the database a name, the collection a name, and ensure that storage capacity is set to fixed.  Then press "OK".

    ![Add Collection](images/new_collection.png "Add Collection")

1. Once the collection is created, a document needs to be added in order to create the index for the Azure Search.  On the Data Explorer page, select the database name->collection name-Documents.

    ![Add Document](images/add_document_collection.png "Add Document")

1. On the right, select Add Document.

    ![Add Document](images/new_document_setup.png "Add Document")

1. Copy the code from [setupdata.json](setupdata.json) and paste the json into the editor.  Then press "Save".

    ![Add Document](images/setup_document_code.png "Add Document")

## Create Azure Search

Azure Search is used to show a business process and another endpoint within the Logic App

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "Azure Search" into the search box and select Azure Search when it pops up

    ![Azure Search](images/azure_search_search.png "Azure Search")

1. On the next blade select Azure Search

    ![Azure Search](images/azure_search.png "Azure Search")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. Give Search Service a URL, location, location, and pricing tier.  Use the same existing Resource Group as our Storage Account just to keep everything organized.  The click "Create".

    ![Create Azure Search](images/new_search_service.png "Create Azure Search")

1. When the deployment finshes, we need to create the index and data source in the search service . Click on the "go to resource" button of the deployment notification

    ![Go to Azure Search](images/search_deployment.png "Go to Azure Search")

1. Click the "Import Data" button at the top of the page.

    ![Import Data](images/import_data_button.png "Import Data")

1. On the Import Data blade, select Connect to your Data

    ![New Data Source](images/data_source_create.png "New Data Source")

1. On the Data Source blade, select DocumentDB

    ![New Data Source](images/docdb_data_source.png "New Data Source")

1. On the New Data Source blade, give it a name and select DocumentDB account

    ![New Data Source](images/new_data_source.png "New Data Source")

1. Select you CosmosDB account, then select the database and collection name.

    ![New Data Source](images/data_source_values.png "New Data Source")

1. Enter the following value into the Query box:

    ```SQL
    SELECT c.id, c.name, c.Attributes, c.Attributes.Category, c._ts
    FROM c where c._ts >= @HighWaterMark
    ```

    Then select "Query results by _ts" check box.  The press "OK".

    ![New Data Source](images/data_source_query.png "New Data Source")

1. On the Customer Index blade, give the Index a name, and ensure that the id is selected a a Key.  Select Name and Category as Searchable and <b>Retrievable</b> and press "OK".

    ![New Index](images/customize_index.png "New Index")

1. On the Create and Indexer Blade, give the Indexer a name and leave the Schedule to Once.  Press "OK".

    ![New Indexer](images/create_indexer.png "New Indexer")

1. Press "OK" on the Import Data blade.

## Create Function

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)

1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "azure functions" into the search box and select Azure Function when it pops up

    ![Function App](images/azure_function_search.png "Function App")

1. On the next blade select Function App

    ![Function App](images/function_search_result.png "Function App")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. On the next screen select a unique name for your function app (confirm with checkmark), again let's use the same existing Resource Group as our Storage Account just to keep everything organized, keep consumption plan selected for the hosting plan then click "Create"

    ![Create Function](images/create_function.png "Create Function")

1. When the deployment finishes, we can start writing our function's code. Click on the "go to resource" button of the deployment notification

    ![Go to Function](images/goto_function.png "Go to Function")

1. Create a new function by clicking on the plus sign next to the functions section on the left

    ![New Function](images/new_function.png "New Function")

1. Then click the link that says "Create this function".

    ![Create HTTP Function](images/create_web_function.png "Create HTTP Function")

1. Copy the code from [attributemapfunction.txt](attributemapfunction.txt) into the run.csx editor.  Press Save.

    ![Add Function Code](images/function_code.png "Add Function Code")

The following steps will rename the function.  Not required, but recommended.

1. (Optional) Select the unique name of your function app.

     ![Rename Function](images/function_rename_select.png "Rename Function")

1. (Optional) Select "Platform Features", then under Development Tools click Console.

    ![Rename Function](images/function_platform_features.png "Rename Function")

1. (Optional) In the Console, type:  rename HttpTriggerCSharp1 \<your name\> where <your name> is the new name of the function.

    ![Rename Function](images/rename_console.png "Rename Function")

1. (Optional) Close the console and select the Overview tab.  Select "Restart" and select "OK" in the popup window.

    ![Restart Function](images/function_restart.png "Restart Function")

## Create Integration Account

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)

1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "integration account" into the search box and select Integration when it pops up

    ![Integration Account](images/integration_account_save.png "Integration Account")

1. On the next blade select Integration account

    ![Integration Account](images/logic_app_integration_account_result.png "Integration Account")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. On the next screen select a  name for your Integration Account (confirm with checkmark), again let's use the same existing Resource Group as our Storage Account just to keep everything organized, select a pricing tier and location. Then click "Create"

    ![Integration Account](images/logic_app_new_integration_account.png "Integration Account")

1. When the deployment finishes, we can start writing our function's code. Click on the "go to resource" button of the deployment notification

    ![Go to Integration Account](images/integration_account_goto.png "Go to Integration Account")

1. When the Integration Account opens, select the Maps tile.

    ![Maps](images/integration_account_maps.png "Maps")

1. In the Maps blade, select Add.

    ![Maps](images/integration_account_add_maps.png "Maps")

1. On the next blade, start by changing the Map type to liquid.

    ![Maps](images/integration_account_map_type.png "Maps")

1. Be sure to create a local copy of the liquid map, [TransformCharacters.liquid](TransformCharacters.liquid)

1. Enter a name and browse to the local copy of the TransformCharacters.liquid file.  The press OK.

    ![Maps](images/integration_account_add_liquid.png "Maps")

The setup steps are now complete.