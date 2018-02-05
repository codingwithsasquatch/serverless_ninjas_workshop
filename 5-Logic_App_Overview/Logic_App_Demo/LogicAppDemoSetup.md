# Serverless Logic Apps Demo Setup

Setup:  Create Azure Storage Account, CosmosDB, Azure Search
This must be completed before giving demo.

## Update Deployment template

1. Open the [deployment.json](deployment.json) file in an editor.

1. Search for api-key, and enter the Azure Search primary admin key from the Logic App demo.  Note there are two api-keys.

1. Search for URI and verify the azure search uris for the data source and indexer.

1. Search for the connection string and update the connection string to the CosmoDB connection created in the Logic Apps demo.  Be sure to add the CosmosDB key.

1. Save the template.json file.

## Use template to create Logic App

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)

1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "template" into the search box and select Logic App when it pops up

    ![Template](images/template_search.png "Template")

1. On the next blade select Template Deployment

    ![Template Deployment](images/template_deployment_results.png "Template Deployment")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. Select "Build your own template in the editor"

    ![Build Template](images/template_build.png "Build Template")

1. Click "Load file"

    ![Build Template](images/template_load_file.png "Build Template")

1. Open the [deployoment.json](deployment.json) file.

    ![Build Template](images/template_json.png "Build Template")

1. Press Save.

    ![Build Template](images/template_save.png "Build Template")

1. Press fill in the values, using the same resource group as the demo.

    ![Build Template](images/template_settings.png "Build Template")

1. Select the terms and agreement check box.

    ![Build Template](images/template_terms.png "Build Template")

1. Select purchase.

    ![Build Template](images/template_purchase.png "Build Template")

1. When the deployment finishes, we need to verify the Logic App. Click on the "go to resource" button of the deployment notification

    ![Build Template](images/template_goto_resource.png "Build Template")

## Create a Storage Account Container

The storage account will be used to upload a file to start the Logic App.

1. When the deployment finishes, we need to create the blob container in the storage account. Open the storage account created in the deployment (does not end in azstorage).

1. Click the Blobs link in the middle of the screen under Services.

    ![Azure Storage](images/storage_blob.png "Azure Storage")

1. On the Blob Service page, select "+ Container"

    ![Create Storage Container](images/add_container.png "Create Storage Container")

1. On the New Container screen, give the container a name and set the access level.  Then press "OK".

    ![Storage Container](images/new_container.png "Create Storage Container")

1. (Optional) It is recommended that you download and install Azure Storage Explorer from [https://azure.microsoft.com/en-us/features/storage-explorer/](https://azure.microsoft.com/en-us/features/storage-explorer/).

    The demo walkthrough does use the Azure Storage Explorer, though the file can be uploaded through the portal.

## Create CosmosDB

Now that we have an storage account let's create an instance of CosmosDB where the messages from the file will be saved.

1. Browse to your resource group and open the Azure Cosmos DB account resource.

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

1. We need to create the index and data source in the search service.  Browse to your resource group and open the Search service resource.

1. Click the "Import Data" button at the top of the page.

    ![Import Data](images/import_data_button.png "Import Data")

1. On the Import Data blade, select Connect to your Data

    ![New Data Source](images/data_source_create.png "New Data Source")

1. On the Data Source blade, select DocumentDB

    ![New Data Source](images/docdb_data_source.png "New Data Source")

1. On the New Data Source blade, give it a name and select DocumentDB account

    ![New Data Source](images/new_data_source.png "New Data Source")

1. Select your CosmosDB account, then select the database and collection name.

    ![New Data Source](images/data_source_values.png "New Data Source")

1. Enter the following value into the Query box:

    ```SQL
    SELECT c.id, c.name, c.Attributes, c.Attributes.Category, c._ts
    FROM c where c._ts >= @HighWaterMark
    ```

    Then select "Query results by _ts" check box.  The press "OK".

    ![New Data Source](images/data_source_query.png "New Data Source")

1. On the Customer Index blade, give the Index a name, and ensure that the id is selected a a Key.  Select Name and Category as Searchable and <b>Retrievable</b> (not shown below) and press "OK".

    ![New Index](images/customize_index.png "New Index")

1. On the Create an Indexer Blade, give the Indexer a name and leave the Schedule to Once.  Press "OK".

    ![New Indexer](images/create_indexer.png "New Indexer")

1. Press "OK" on the Import Data blade.

## Create Function

1. We need to create the function in the function app.  Browse to your resource group and open the App Service resource.

1. Create a new function by clicking on the plus sign next to the functions section on the left

    ![New Function](images/new_function.png "New Function")

1. Then click the link that says "Create this function".

    ![Create HTTP Function](images/create_web_function.png "Create HTTP Function")

1. Copy the code from [attributemapfunction.txt](setup_data/attributemapfunction.txt) into the run.csx editor.  Press Save.

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

1. Be sure to create a local copy of the liquid map, [TransformCharacters.liquid](setup_data/TransformCharacters.liquid)

1. Enter a name and browse to the local copy of the TransformCharacters.liquid file.  The press OK.

    ![Maps](images/integration_account_add_liquid.png "Maps")

The setup steps are now complete.