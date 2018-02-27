# Serverless Event Streaming Hands-On Lab

## Event Processing from Event Hub

![Event Hub Diagram](images/eventhub_diagram.png "Event Hub Diagram")

### Create Event Hub

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "event hubs" into the search box and select Event Hub when it pops up

    ![Event Hubs](images/event_hub.png "Event Hubs")

1. On the next blade select Event Hubs

    ![Event Hubs](images/event_hubs.png "Event Hubs")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. Give it a name, location, resource group, location, and scale then click create

    ![Create Event Hub](images/create_event_hub.png "Create Event Hub")

1. When the deployment finshes, we need to create the event hub in the event hub namespace. Click on the "go to resource" button of the deployment notification

    ![Go to Event Hub](images/goto_event_hub.png "Go to Event Hub")

1. Click the "Event Hubs" link under Entities

    ![Event Hubs](images/event_hub_entities.png "Event Hubs")

1. Click the New Event Hub button

    ![New Event Hub](images/new_event_hub.png "New Event Hub")

1. Then we can give the event hub a name and leave the rest of the settings as the defaults and click create

    ![New Event Hub Settings](images/new_event_hub_settings.png "New Event Hub Settings")

1. Once your event hub entity has been created click on it and then click Shared Access policies

    ![Shared Access policies](images/event_hub_sas.png "Shared Access policies")

1. Click Add

    ![Add](images/add.png "Add")

1. Give you policy a name, select the send right, and then click create

    ![SAS Settings](images/event_hub_sas_properties.png "SAS Settings")

1. Click on the policy you just created and save the Primary Connection String and policy name somewhere as we will need this later

    ![SAS Connection String](images/event_hub_connection_string.png "SAS Connection String")

### Create CosmosDB

Now that we have an event hub let's create an instance of CosmosDB where we can put these messages.

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "Azure Cosmos DB" into the search box and select Azure Cosmos DB when it pops up

    ![Azure Cosmos DB](images/cosmosdb_search.png "Azure Cosmos DB")

1. On the next blade select Azure Cosmos DB

    ![Azure Cosmos DB](images/cosmosdb.png "Azure Cosmos DB")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. Now let's give it a name,  use SQL as the API (since this data is in JSON format already), and use the same existing Resource Group as our Event Hub just to keep everything organized. Then click "Create"

    ![Create Cosmos DB](images/create_cosmosdb.png "Create Cosmos DB")

### Create Function

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "azure functions" into the search box and select Event Hub when it pops up

    ![Function App](images/function_search.png "Function App")

1. On the next blade select Event Hubs

    ![Function App](images/function.png "Function App")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. On the next screen select a unique name for your function app (confirm with checkmark), again let's use the same existing Resource Group as our Event Hub just to keep everything organized, keep consumption plan selected for the hosting plan, and make sure you choose "On" for Application Insights and then click "Create"

    ![Create Cosmos DB](images/create_function.png "Create Cosmos DB")

1. When the deployment finshes, we can start writing our function's code. Click on the "go to resource" button of the deployment notification

    ![Go to Function](images/goto_function.png "Go to Function")

1. Create a new function by clicking on the plus sign next to the functions section on the left

    ![New Function](images/new_function.png "New Function")

1. Then click the link that says create your own custom function

    ![Create Custom Function](images/create_custom_function.png "Create Custom Function")

1. Type Event Hub in the search box then click the "JavaScript" language option for the "Event Hub trigger" template

    ![Choose Function Template](images/choose_function_template.png)

1. Click new for the Event Hub connection

    ![New Event Hub connection](images/new_event_hub_connection.png "New Event Hub connection")

1. Select the Event Hub you set up in the previous step and "RootManageSharedAccessKey" for the policy. Then click Select

    ![Select Event Hub connection](images/select_event_hub_connection.png "Select Event Hub connection")

1. Now enter the name of the Event Hub in the Event Hub Name field and then click Create

    ![Finish New Function](images/finish_function_settings.png "Finish New Function")

1. Now let's add an output binding for Cosmos DB. Click the integrate link for your function

    ![Integrate Function](images/integrate_function.png "Integrate Function")

1. Click the "New Output" button

    ![New Output](images/new_function_output.png "New Output")

1. Select the CosmosDb output and click the Select button.

    ![CosmosDB output](images/function_cosmosdb_output.png "CosmosDB Output")

1. Select the "Use function return value" checkbox. Enter a database name and collection name to use and then check the create database and collection check box then click the new button next to the Cosmos DB account connection

    ![CosmosDB output](images/function_cosmosdb_settings.png "CosmosDB Output")

1. On the  and select the cosmos db we set up in the previous step

    ![CosmosDB account](images/function_cosmosdb_account.png "CosmosDB account")

1. Then click "Save" and we are ready to start writing our code!

1. Click on the name of your function. and the code window will open

    ![function name](images/function_name.png "function name")

1. Below is the code we will use to insert the events into Cosmos DB

    ```javascript
        module.exports = function (context, eventHubMessages) {
            context.log(`JavaScript eventhub trigger function called for message array ${JSON.stringify(eventHubMessages)}`);
            var messages = [];

            eventHubMessages.forEach(message => {
                context.log(`Processed message ${message.description}`);
                messages.push(message);
            });

            context.done(null, messages);
        };
    ```

    ```csharp
        #r "Newtonsoft.Json"

        using System;
        using Newtonsoft.Json.Linq;
        
        public static void Run(string[] eventHubMessages, ICollector<dynamic> documents, TraceWriter log)
        {
            log.Info($"C# Event Hub trigger function processed a message: {eventHubMessages}");
        
            foreach (var eventHubMessage in eventHubMessages){
                log.Info($"Processed message: {eventHubMessage}");
                dynamic doc = JObject.Parse(eventHubMessage);
                documents.Add(doc);
            }
        }
    ```

1. Now we can start using it. Click on the function app name

    ![function app](images/function_app.png "function app")

1. Click on the Application Insights link

    ![app insights](images/application_insights.png "app insights")

1. Click the Live Stream button

    ![app insights live stream](images/app_insights_live_stream.png "app insights live stream")

1. In another new window go to [https://aka.ms/eventgen](https://aka.ms/eventgen) in a web browser

1. Select Event Hub as the messaging service

    ![eventgen event hub](images/eventgen_eventhub.png "eventgen event hub")

1. Paste in the connection string and event hub name you saved earlier

    ![eventgen event hub settings](images/eventgen_eventhub_settings.png "eventgen event hub settings")

1. Choose Ninja Battle, set the duration to 1 minute, set the frequency to whatever you'd like, and click start!

    ![eventgen messages](images/eventgen_messages.png "eventgen messages")

1. Now let's watch the live streaming in Application Insights

    ![app insights live stream](images/app_insights_live_stream_dashboard.png "app insights live stream")

## Event Processing from Event Grid

![Event Grid Diagram](images/eventgrid_diagram.png "Event Grid Diagram")

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)
1. Click the New button

    ![New Button](images/new_button.png "New Button")

1. Type "event grid topic" into the search box and select Event Grid Topic when it pops up

    ![Event Grid Topic](images/eventgrid_topic.png "Event Grid Topic")

1. Click "Event Grid"

    ![Event Grid Topic](images/select_eventgrid.png "Event Grid Topic")

1. Then click "Create"

    ![Create](images/create.png "Create")

1. Give it a name, a location, and again let's use the same existing Resource Group as our Function App and Event Hub just to keep everything organized and then click create

    ![Create Event Grid Topic](images/eventgrid_topic_create.png "Create Event Grid Topic")

1. When the deployment finshes, we can create a function that subscripbes to the Event Grid Topic we just created. Click on the "go to resource group" button of the deployment notification

    ![Go to Resource Group](images/goto_resourcegroup.png "Go to Resource Group")

1. Then click on your function app

    ![Function](images/click_function.png "Function")

1. Create a new function by clicking on the plus sign next to the functions section on the left

    ![New Function](images/new_function.png "New Function")

1. type "event grid" in the search box and click on the Javascript link of the "Event Grid trigger"

    ![Event Grid trigger](images/eventgrid_function_template.png "Event Grid trigger")

1. Give your function a name and click "Create"

    ![Create Event Grid trigger](images/create_eventgrid_function_trigger.png "Create Event Grid trigger")

1. Now let's setup the Event Grid subscription. Start by clicking on the "Add Event Grid subscription" link in the uper right-hand corner

    ![Add Event Grid subscription](images/add_eventgrid_subscription.png "Add Event Grid subscription")

1. In the menu that opens. Enter a Name for the subscription, set the Topic Type to "Event Grid Topics," make sure the correct subscription, resource group, and instance of your Event Grid Topic are selected, and click create

    ![Event Grid subscription settings](images/eventgrid_subscription_settings.png "Event Grid subscription settings")

1. Now let's add an output binding for Cosmos DB, just like we did before with the Event Hub. Click the integrate link for your function

    ![Integrate Event Grid Function](images/integrate_eventgrid_function.png "Integrate Event Grid Function")

1. Click the "New Output" button

    ![New Output](images/new_eventgrid_function_output.png "New Output")

1. Select the CosmosDb output and click the Select button.

    ![CosmosDB output](images/function_eventgrid_cosmosdb_output.png "CosmosDB Output")

1. Select the "Use function return value" checkbox. Enter a database name and collection name to use and then check the create database and collection check box then click the new button next to the Cosmos DB account connection. Then click "Save" and we are ready to start writing our code!

    ![CosmosDB output](images/function_eventgrid_cosmosdb_settings.png "CosmosDB Output")

1. Click on the name of your function. and the code window will open

    ![function name](images/function_eventgrid_name.png "function name")

1. Below is the code we will use to insert the events into Cosmos DB

    ```javascript
        module.exports = function (context, eventGridEvent) {
            context.log(eventGridEvent.Data);
            context.done(null, eventGridEvent.Data);
        };
    ```


    ```csharp
        #r "Microsoft.Azure.WebJobs.Extensions.EventGrid"
        #r "Newtonsoft.Json"

        using Newtonsoft.Json.Linq;
        using Microsoft.Azure.WebJobs.Extensions.EventGrid;

        public static void Run(EventGridEvent  eventGridEvent, out dynamic doc, TraceWriter log)
        {
            log.Info(eventGridEvent.Data.ToString());
            doc = JObject.Parse(eventGridEvent.Data.ToString());
        }
    ```

1. Now we can start using it. Click on the function app name

    ![function app](images/function_app.png "function app")

1. Click on the Application Insights link

    ![app insights](images/application_insights.png "app insights")

1. Click the Live Stream button

    ![app insights live stream](images/app_insights_live_stream.png "app insights live stream")

1. In another new window go to [https://aka.ms/eventgen](https://aka.ms/eventgen) in a web browser

1. Select Event Grid as the messaging service

    ![eventgen Event Grid](images/eventgen_eventgrid.png "eventgen Event Grid")

1. Paste in the connection string and event hub name you saved earlier

    ![eventgen Event Grid settings](images/eventgen_eventgrid_settings.png "eventgen Event Grid settings")

1. Choose Ninja Battle, set the duration to 1 minute, set the frequency to whatever you'd like, and click start!

    ![eventgen messages](images/eventgen_messages.png "eventgen messages")

1. Now let's watch the live streaming in Application Insights

    ![app insights live stream](images/app_insights_live_stream_dashboard.png "app insights live stream")
