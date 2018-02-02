# Serverless Logic Apps Lab Setup

The following will setup the Logic App that the student will send messages to in the Lab.  This needs to be done at least a day before and can be resused for each delivery of the lab.

## Update Deployment template

1. Open the [template.json](template.json) file in an editor.

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

1. Open the [template.json](template.json) file.

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

    ![Go to Logic App](images/template_goto_deployment.png "Go to Logic App")

1. Ensure all values are entered in the CosmosDB action item and the Data Source and Indexer actions.

## Create API Management

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)

1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "api management" into the search box and select API Management when it pops up

    ![API Management](images/api_management_search.png "API Management")

1. On the next blade select API Management

    ![API Management](images/api_management_result.png "API Management")

1. Then click "Create"

    ![Create](images/Create.png "Create")

1. Then click Enter the name, the existing resource group, and organization name, and select a pricing tier.

    ![API Management](images/api_management_details.png "API Management")

1. Then click "Create"

    ![Create](images/create.png "Create")

Note:  API Management can take several minutes to create.

1. Open the API Management Resource.

1. From the right hand side of the API Management blade, select "APIs".

    ![API Management](images/api_management_apis.png "API Management")

1. Under Add API, select Logic App.

    ![API Management](images/api_management_logic_app.png "API Management")

1. Browse to the the Logic App just uploaded from the template. The Display Name and name will be populated based on the logic app name.  You can change the values if needed.

    ![API Management](images/api_management_create_logic_app.png "API Management")

1. Select a the Unlimited option from the Products drop down box.

    ![API Management](images/api_mangement_products.png "API Management")

1. Select Create.

    ![API Management](images/api_management_create.png "API Management")

1. Select the settings tab.

    ![API Management](images/api_management_settings.png "API Management")

1. Make note of the Base URL.  This URL will be given to the students.  Updating a file on Git, or writing the URL on the board.

    ![API Management](images/api_management_base_url.png "API Management")