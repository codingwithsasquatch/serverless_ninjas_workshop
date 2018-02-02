# Serverless Logic Apps Demo

You must go through Logic App Setup at least once before the following demo will work (LogicAppDemoSetup.md).

Recommend to go through the steps to clear data (cleardata.md).

## Overview

The following Logic App will upload a file that contains a list of character's from Marvel's database.  The list is in a json document, with pipeline delimited text to define the characteristics the charcter.

Once uploaded, each character is then saved as documents in a CosmosDB database and an Azure Search service is updated.  The search service can then be used to search for all characters that contain the word "Ninja".

## Azure Storage Explorer

This demo uses the Azure Storage Explorer [https://azure.microsoft.com/en-us/features/storage-explorer/](https://azure.microsoft.com/en-us/features/storage-explorer/).  It is not required, but recommended and covered in the demo.  If using, be sure to login and browse to the storage account created in LogicAppDemoSetup.

## Save data in a text editor

The last step is to call Azure Search.  It is recommended that before starting the demo the following item is saved to a text file to be easily retrieved.

1. Open your Azure Search instance and select Keys.  Copy the Primary Admin Key to the text file.

    ![Search Key](images/search_key.png "Search Key")

1. Copy the following code to the text file and change the values to the correct values from Azure Search and Cosmos DB

```json
     {
   "container": {
    "name": "<Cosmos SQL API collection>"
     },
    "credentials": {
    "connectionString": "AccountEndpoint=https://[your account name].documents.azure.com;AccountKey=[your cosmos db primary account key];Database=[your database id]"
    },
    "name": "<Search Data Source>",
    "type": "documentdb",
      "dataChangeDetectionPolicy" :
      {"@odata.type" : "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy",  
    "highWaterMarkColumnName" : "_ts"
    }
    }
```

## Create Logic App

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "Logic App" into the search box and select Logic App when it pops up

    ![Logic App](images/logic_app_search.png "Logic App")

1. On the next blade select Logic App

    ![Logic App](images/logic_app_result.png "Logic App")

1. Then click "Create"

    ![Create](images/Create.png "Create")

1. Give it a name, location, and use the same existing Resource Group as our setup.  The click Create.

    ![Create Logic App](images/create_logic_app.png "Create Logic App")

1. When the deployment finishes, we need to create the Logic App. Click on the "go to resource" button of the deployment notification

    ![Go to Logic App](images/goto_logic_app.png "Go to Logic App")

1. The Logic App opens to an empty designer page.  You can use a tempate to create a Logic App, however we are starting with a blank Logic App.  To find the blank logic app, scroll down a bit to the middle of the page.  Click on the "Blank Logic App" tile.

    ![Logic App Template](images/logic_app_template.png "Logic App Template")

1. The designer then opens to the required first trigger.  In the "Search all connectors and triggers" text box, type "blob".

    ![Logic App Trigger](images/logic_app_blob_search.png "Logic App Trigger")

1. Select "Azure Blob Storage" under the Triggers section.

    ![Logic App Trigger](images/logic_app_select_blob.png "Logic App Trigger")

1. Enter the Connection Name and select the name of the storage account.  Note that the Connection name is different from the storage account name and must be entered before the Create button becomes available.

    ![Logic App Trigger](images/logic_app_blob_create.png "Logic App Trigger")

1. Select "Create".

1. Leave the Interval at 3 minutes.

    ![Logic App Trigger](images/logic_app_blob_interval.png "Logic App Trigger")

1. Select the Container text box and select the Azure Storage container from the Azure Blob Stroage pop out.

    ![Logic App Trigger](images/logic_app_blob_container.png "Logic App Trigger")

    The Azure Storage Blob trigger just notifies the Logic App that there is a blob that was put in the container.  It does not get the content.  We now need to get the content.

1. Select New Step.

    ![New Step](images/new_step.png "New Step")

1. Click Add Action.

    ![Add Action](images/add_action.png "Add action")

1. In the "Choose an action" search box, type blob.

    ![Logic App Trigger](images/logic_app_blob_search.png "Logic App Trigger")

1. Under the Actions tab, select "Azure Blob Storage - Get blob content using file path.

    ![Logic App Trigger](images/logic_app_get_blob_content.png "Logic App Trigger")

1. In the Get blob content using path action, select the Blob path text box.  In the Dynamic Content editor, select Path from the list.

    ![Logic App Trigger](images/logic_app_blob_path.png "Logic App Trigger")

    Parse JSON is a commonly used action that will take a JSON message and strongly typed the message within the logic app.  The properties within the message can then be used in following actions.

1. Select New Step.

    ![New Step](images/new_step.png "New Step")

1. Click Add Action.

    ![Add Action](images/add_action.png "Add action")

1. In the "Choose an action" search box, type "parse json" with a space.

    ![Parse JSON](images/logic_app_parsejson_s.png "Parse JSON")

1. Under the Actions tab, select "Data Operations - Parse JSON".

    ![Parse JSON](images/logic_app_select_parse.png "Parse JSON")

    The incoming message is in a JSON format, but due to the encoding on the document the Parse JSON action cannot type the message.  To get around this, we will use an Expression to convert the string into JSON string.

1. Select the Content text box.  The editor will appear on the screen.  Select the Expression tab.

    ![Parse Content](images/logic_app_expression.png "Parse Content")

1. In the expression tab, scroll down to json() under the Conversion functions section.

    ![Expression](images/logic_app_expression_json.png "Expression")

1. Select the Dynamic content tab.

    ![Dynamic Properties](images/locic_app_json_dynamic_content.png "Dynamic Properties")

1. Click File Content under the "Get blob content using path".

    ![File Content](images/logic_app_json_body.png "File Content")

1. Select "OK".

    Note:  Do NOT press Enter.

1. Click the link "Use sample payload to generate schema".

    ![Parse Content](images/logic_app_sample_payload.png "Parse Content")

1. Copy the code from [sampleschema.json](sampleschema.json) and paste it into the editor.  Then press Done.

    ![Schema Editor](images/logic_app_parse_schema.png "Schema Editor")

## Add Data to CosmosDB

The following steps will add the characters to the CosmosDB database.

In order to save the characters in the correct format we must first parse the text of the JSON to split by the pipeline character.  The pre-created Attribute function will be used to perform this action.

1. Select New Step.

    ![New Step](images/new_step.png "New Step")

1. Click Add Action.

    ![Add Action](images/add_action.png "Add action")

1. In the "Choose an action" search box, type "azure function".

    ![Azure Function](images/logic_app_azure_function_search.png "Azure Function")

1. Under the Actions tab, select "Azure Functions - Choose an Azure function".

    ![Azure Function](images/logic_app_select_function.png "Azure Function")

1. Then under the Actions tab, select the function that was created in the demo setup.

    ![Azure Function](images/logic_app_select_specific_function.png "Azure Function")

1. Next under the Actions tab, select Azure - Functions - <b>function name</b>.

    ![Azure Function](images/logic_app_function_format_attributes.png "Azure Function")

1. Click in the Request Body text box.  Under Dynamic content, scroll and select text.

    ![Azure Function](images/logic_app_function_body.png "Azure Function")

    A foreach loop will be created with mediawiki as the output.

    ![Azure Function](images/logic_app_foreach.png "Azure Function")

    The text property has now been formatted into a json property.  We need to use a liquid map to take two json messages and format it into a single message.  We will need to save the logic app and associate the Integration account.

1. Save the logic app.

    ![Save Logic App](images/logic_app_save.png "Save Logic App")

1. Once saved, close the designer.

    ![Close Logic App](images/logic_app_close.png "Close Logic App")

1. On the overview screen, select Workflow Settings from the right hand side.

    ![Workflow Settings](images/logic_app_workflow_settings.png "Workflow Settings")

1. On the Workflow settings blade, select the Integration account created in the setup guide from the drop down list.

    ![Integration Account](images/logic_app_integration_account.png "Integration Account")

1. Press save.

    ![Save](images/save.png "Save")

1. Once saved, select the Overview tab and click Edit.

    ![Edit Logic App](images/logic_app_edit.png "Edit Logic App")

1. Scroll to the bottom of the logic app and within the foreach, select Add an Action

    ![Add Action](images/logic_app_foreach_action.png "Add Action")

1. In the "Choose an action" search box, type "liquid".

    ![Liquid](images/logic_app_liquid_search.png "Liquid")

1. Under the Actions tab, select "Liquid- Transform JSON to JSON".

    ![Liquid](images/logic_app_liquid_json_json.png "Liquid")

1. In the drop down box of the Map, select the map stored in the Integration Account.

    ![Liquid](images/logic_app_map.png "Liquid")

1. Select the content textbox, then select the Code view button at the top of the page.

    ![Code View](images/logic_app_code_view.png "Code View")

    Code view allows the developer to type a Logic App Expression directly into the JSON file.  We are going to enter an expression that will take the current JSON message of the character and combine it with the output of the liquid map.

1. Find the content line of the Transform action.  Enter the following code:  

```logic app code
@addProperty(items('For_each'), 'attributes', body('FormatAttributes'))
```

![Code View](images/logic_app_transform_content.png "Code View")

1. Press Designer at the top of the page.

    ![Designer](images/logic_app_designer.png "Designer")

1. Scroll to the bottom of the logic app and within the foreach, select Add an Action

    ![Add Action](images/logic_app_foreach_action.png "Add Action")

1. In the "Choose an action" search box, type "cosmos".

    ![CosmosDB](images/logic_app_cosmos_search.png "CosmosDB")

1. Under the Actions tab, select "Azure Cosmos DB - Create or update document".

    ![CosmosDB](images/logic_app_cosmos_create_doc.png "CosmosDB")

1. Enter the Connection Name and select the name of the Cosmos DB.  Note that the Connection name is different from the Cosmos DB name and must be entered before the Create button becomes available.

    ![CosmosDB](images/logic_app_cosmos_select_db.png "CosmosDB")

1. Enter the Database ID and Collection ID

    ![CosmosDB](images/logic_app_cosmos_values.png "CosmosDB")

1. Click in the Document text box and select Transformed content from the dynamic content tab.

    ![CosmosDB](images/logic_app_cosmos_data.png "CosmosDB")

## Update Azure Search Index

The last part of the process will update Azure Search to include all of the documents just added to CosmosDB

You will need to have the Azure Search URL, Data Source Name, Indexer Name, and API Key copied and easily retrievable.

1. Select New Step.

    ![New Step](images/new_step.png "New Step")

1. Click Add Action.

    ![Add Action](images/add_action.png "Add action")

1. From the list of connectors, select HTTP.

    ![HTTP](images/logic_app_select_http.png "[HTTP")

1. Under the Actions tab, select "HTTP-HTTP"

    ![HTTP](images/logic_app_select_http_http.png "[HTTP")

1. Select the PUT method from the Method dropdown list.

    ![PUT](images/logic_app_http_put.png "PUT")

1. In the Headers values, select the "Enter key" text box and type "api-key".

    ![PUT](images/logic_app_api_key_put.png "PUT")

1. In the Headers values, select the "Enter value" text box and paste in the Azure Search api-key.

    ![PUT](images/logic_app_search_key.png "PUT")

1. In the Headers values on the following line, select the "Enter key" text box and type "Content-Type".

    ![PUT](images/logic_app_search_content_type.png "PUT")

1. In the Headers values, select the "Enter value" text box and paste in the Azure Search "application/json".

    ![PUT](images/logic_app_http_put_type.png "PUT")

1. Select the body text box.  Change the values in the code below to match the names of your services.  The image shows the values given for the this example.  More information on the REST calls of Azure Search for Data Source can be found here:  [https://docs.microsoft.com/en-us/rest/api/searchservice/create-data-source](https://docs.microsoft.com/en-us/rest/api/searchservice/create-data-source)

```json
     {
    "container": {
    "name": "<Cosmos SQL API collection>"
    },
    "credentials": {
    "connectionString": "AccountEndpoint=https://[your account name].documents.azure.com;AccountKey=[your cosmos db primary account key];Database=[your database id]"
    },
    "name": "<Search Data Source>",
    "type": "documentdb",
      "dataChangeDetectionPolicy" :
     {"@@odata.type" : "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy",  
    "highWaterMarkColumnName" : "_ts"    }
    }
```

![Update Data Source](images/logic_app_http_put_body.png "Update Data Source")

1. Change the following URL to be the correct service names and add to the URL text box.

    https://<b>search service name</b>.search.windows.net/datasources/<b>data source name</b>?api-version=2016-09-01.

    ![Update Data Source](images/logic_app_http_put_url.png "Update Data Source")

1. Now the indexer needs to be updated. Select New Step.

    ![New Step](images/new_step.png "New Step")

1. Click Add Action.

    ![Add Action](images/add_action.png "Add action")

1. From the list of connectors, select HTTP.

    ![HTTP](images/logic_app_select_http.png "[HTTP")

1. Under the Actions tab, select "HTTP-HTTP"

    ![HTTP](images/logic_app_select_http_http.png "[HTTP")

1. Select the POST method from the Method dropdown list.

    ![POST](images/logic_app_http_post.png "POST")

1. In the Headers values, select the "Enter key" text box and type "api-key".

    ![POST](images/logic_app_api_key_put.png "POST")

1. In the Headers values, select the "Enter value" text box and paste in the Azure Search api-key.

    ![POST](images/logic_app_search_key.png "POST")

1. Update the following URL with the correct values and paste into the URL box.

    https://<b>search service name</b>.search.windows.net/indexers/<b>indexer name</b>/run?api-version=2016-09-01.

    ![Update Indexer](images/logic_app_http_post_url.png "Update Indexer")

## Run Demo

1. Save the Logic App.

    ![Save Logic App](images/logic_app_save.png "Save Logic App")

1. Once saved, close the designer.

    ![Close Logic App](images/logic_app_close.png "Close Logic App")

1. Open Azure Storage Explorer and browse to the storage account.  Open the storage account.

    ![Azure Storage Explorer](images/storage_explorer_browse.png "Azure Storage Explorer")

1. Open Blob containers and select the container.

    ![Azure Storage Explorer](images/storage_explorer_container.png "Azure Storage Explorer")

1. Copy or upload the [Characters.json](Character.json) file to the Storage Blob container.

    ![Azure Storage Explorer](images/azure_storage_explorer_upload.png "Azure Storage Explorer")

1. Click back to the Logic App page and select Run Trigger->When_a_blob_is_added_or_modified.  This will run the logic app without waiting the three minutes polling time.

    ![Run Logic App](images/logic_app_run_trigger.png "Run Logic App")

1. Press Refresh.

    ![Run Logic App](images/logic_app_refresh.png "Run Logic App")

1. Continue pressing refresh until a Succeeded status appears in the run history.

    ![Run Logic App](images/logic_app_run_history.png "Run Logic App")

1. Click the succeed message.

1. On the run details screen, quickly show the green check marks on the actions.  Then select one of the actions in the For each loop.  Show the input and output messages.  (Note, actions outside of the foreach loop will require the message to be downloaded)

    ![Run Logic App](images/logic_app_run_details.png "Run Logic App")

1. Open Azure Search service and show the number of documents that have been uploaded.

    ![Run Logic App](images/azure_search_documents.png "Run Logic App")

1. If there is time, do a searhc using the Search Explorer

    ![Run Logic App](images/azure_search_results.png "Run Logic App")
