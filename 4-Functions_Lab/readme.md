# サーバーレス イベントストリーミング　ハンズオンラボ

## イベントハブからのイベントを処理

![Event Hub Diagram](images/eventhub_diagram.png "Event Hub Diagram")

### イベントハブの作成

1. Azure ポータルに接続。[https://portal.azure.com](https://portal.azure.com)

1. 「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. 検索ボックスより "event hubs" と入力して候補から選択。

    ![Event Hubs](images/event_hub.png "Event Hubs")

1. 検索結果より Event Hubs を選択。

    ![Event Hubs](images/event_hubs.png "Event Hubs")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")

1. 名前、価格レベル、リソースグループ、場所などを指定して、「作成」をクリック。

    ![Create Event Hub](images/create_event_hub.png "Create Event Hub")

1. 作成が完了したら、ハブを追加するため、通知からリソースへ移動。もしくは、リソース グループの一覧より、作成した Event Hub を選択して移動。

    ![Go to Event Hub](images/goto_event_hub.png "Go to Event Hub")

1. エンティティメニューにある「Event Hubs」をクリック。

    ![Event Hubs](images/event_hub_entities.png "Event Hubs")

1. 「イベント ハブ」ボタンをクリックして新規にハブを作成。

    ![New Event Hub](images/new_event_hub.png "New Event Hub")

1. 名前を指定。他の設定は既定のままで「作成」をクリック。

    ![New Event Hub Settings](images/new_event_hub_settings.png "New Event Hub Settings")

1. 作成されたイベントハブをクリックし、「共有アクセスポリシー」をクリック。

    ![Shared Access policies](images/event_hub_sas.png "Shared Access policies")

1. 「追加」をクリック。

    ![Add](images/add.png "Add")

1. ポリシーに名前を付けて、「送信」を選択後、「作成」をクリック。

    ![SAS Settings](images/event_hub_sas_properties.png "SAS Settings")

1. 後で利用するため、作成されたポリシーをクリックして、「接続文字列　- 主キー」の値とポリシーの名前をどこかに保存。

    ![SAS Connection String](images/event_hub_connection_string.png "SAS Connection String")

### CosmosDB の作成

イベントハブは作成したので、次にハブからのメッセージを保存する CosmosDB を作成します。

1. Azure ポータルに接続。[https://portal.azure.com](https://portal.azure.com)

1. 「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. "Azure Cosmos DB" と入力して候補から選択。

    ![Azure Cosmos DB](images/cosmosdb_search.png "Azure Cosmos DB")

1. Azure Cosmos DB を選択。

    ![Azure Cosmos DB](images/cosmosdb.png "Azure Cosmos DB")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")

1. サブスクリプションとリソースグループを選択。

    ![Azure Cosmos DB Subscription](images/cosmosdb_subscription.png "Create")
    
1. 名前を指定後、API より「SQL」を選択して、「Review + create」をクリック。最終確認画面で「Create」をクリック。

    ![Create Cosmos DB](images/create_cosmosdb.png "Create Cosmos DB")

### Function の作成

1.  Azure ポータルに接続。[https://portal.azure.com](https://portal.azure.com)

1. 「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. "function app" と入力して候補から選択。

    ![Function App](images/function_search.png "Function App")

1. Function App を選択。

    ![Function App](images/function.png "Function App")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")

1. アプリ名を指定し、リソースグループは既存のグループを選択。ランタイムスタックでは「JavaScript」を選択。その他の OS、ホスティングプランや場所、Application Insights の場所は以下の画面の通り選択して「作成」をクリック。

    ![Create Function](images/create_function.png "Create Funcions")

1. 作成が完了したら、通知またはリソースグループより、作成した Function App へ移動。

    ![Go to Function](images/goto_function.png "Go to Function")

1. 関数を選択し、「新しい機能」をクリックして関数を作成。

    ![New Function](images/new_function.png "New Function")

1. 検索ボックスに Event Hub を入力し、"Event Hub trigger" テンプレートを選択。

    ![Choose Function Template](images/choose_function_template.png)
    
1. 初めての場合、「拡張機能がインストールされていません」メッセージが出るため、「インストール」を選択。完了したら「続行」をクリック。

    ![Function Install Template](images/install_extension.png)

1. イベントハブ接続で「新規」をクリック。

    ![New Event Hub connection](images/new_event_hub_connection.png "New Event Hub connection")

1. 作成したイベントハブを選択し、ポリシーで "RootManageSharedAccessKey" を指定後「選択」をクリック。

    ![Select Event Hub connection](images/select_event_hub_connection.png "Select Event Hub connection")

1. イベントハブ名を入力して、「作成」をクリック。

    ![Finish New Function](images/finish_function_settings.png "Finish New Function")

1. Click the integrate link for your function

    ![Integrate Function](images/integrate_function.png "Integrate Function")

1. Update the parameter name and click save.

    ![Parameter name](images/integrate_function_parameter_name.png "Parameter name")

1. Click the "New Output" button

    ![New Output](images/new_function_output.png "New Output")

1. Select the CosmosDb output and click the Select button.

    ![CosmosDB output](images/function_cosmosdb_output.png "CosmosDB Output")

1. Enter a value Document parameter name, this is the object that will be posted to Cosmos DB. Enter a database name and collection name to use and then check the create database and collection check box then click the new button next to the Cosmos DB account connection

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

        context.bindings.documents = messages;
        context.done();
    };
    ```

    ```csharp
    #r "Newtonsoft.Json"

    using System;
    using Newtonsoft.Json.Linq;

    public static async Task Run(string[] eventHubMessages, IAsyncCollector<dynamic> documents, TraceWriter log)
    {
        log.Info($"C# Event Hub trigger function processed a message: {eventHubMessages}");

        foreach (var eventHubMessage in eventHubMessages){
            log.Info($"Processed message: {eventHubMessage}");
            dynamic doc = JObject.Parse(eventHubMessage);
            await documents.AddAsync(doc);
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

## イベントグリッド経由で Blob ストレージイベントを処理

![Event Grid Diagram](images/eventgrid_lab.png "Event Grid Diagram")

1. Azure ポータルに接続。[https://portal.azure.com](https://portal.azure.com)

1. 「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. "storage account" と入力して候補から選択。

    ![Storage Account](images/storage_account.png "Storage Account")

1. 「ストレージ アカウント」を選択。

    ![Storage Account](images/storageaccount.png "Storage Account")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")
    
1. 「リソースグループ」より新規作成をクリックして、新しくリソースグループを作成します。

    ![ResourceGroup](images/new_resourcegroup.png "RG") 

1. ストレージアカウント名、場所を指定。種類では「StorageV2(汎用v2) を選択し、「確認および作成」をクリック。検証が終わったら「作成」をクリック。

    ![Create Storage Account](images/create_storage_account.png "Create Storage Account")

1. 作成が完了したら、「リソースへ移動」をクリック。

    ![Go to Resource Group](images/storage_account_goto_resource.png "Go to Resource Group")

1. 概要の画面から、「BLOB」をクリック。

    ![Blobs](images/storage_account_blobs.png "Blobs")

1. 「コンテナー」ボタンをクリック。名前を付け、アクセスレベルは既定のまま、「OK」をクリック。

    ![New Container](images/storage_account_new_container.png "New Container")

1. 作成済の Function App に戻り、関数を選択。「新しい機能」をクリック。

    ![New Function](images/new_function.png "New Function")

1. 検索ボックスに "event grid" と入力して、"Event Grid trigger" を選択。

    ![Event Grid trigger](images/eventgrid_function_template.png "Event Grid trigger")

1. 初めての場合は拡張機能のインストールが表示されるので、「インストール」をクリック。
    
    ![Eventgrid Extension](images/install_eventgrid_extension.png "Install EventGrid Extension")

1. 関数の作成で、「作成」をクリックします。

    ![Create Event Grid trigger](images/create_eventgrid_function_trigger.png "Create Event Grid trigger")

1. 次にイベントグリッドのサブスクリプションを作成します。ファンクションの画面右上にある「Evet Grid サブスクリプションの追加」をクリックします。

    ![Add Event Grid subscription](images/add_eventgrid_subscription.png "Add Event Grid subscription")

1. サブスクリプションの名前を入力し、「Topic Type」で「Storage Accounts」を選択します。Azure サブスクリプションとリソースグループを選択したら Instance で作成済のブロブストレージを選択します。「Subscribe to all event types」のチェックを外し、明示的に項目一覧より「Blob Created」のみ選択します。最後に「Suffix Filter」に「.png」を指定して「Create」をクリックします。

    ![Event Grid blob subscription settings](images/eventgrid_blob_subscription_settings.png "Event Grid blob subscription settings")

1. Now let's add an output binding for Cosmos DB, just like we did before with the Event Hub. Click the integrate link for your function

    ![Integrate Event Grid Function](images/integrate_eventgrid_function.png "Integrate Event Grid Function")

1. Click the "New Output" button

    ![New Output](images/new_eventgrid_function_output.png "New Output")

1. Select the CosmosDb output and click the Select button

    ![CosmosDB output](images/function_eventgrid_cosmosdb_output.png "CosmosDB Output")

1. Update the parameter, database and collection names to use. Select the option to create the database and collection. Finally, click "Save" and we are ready to start writing our code!

    ![CosmosDB output](images/function_eventgrid_cosmosdb_settings.png "CosmosDB Output")

1. Click on the name of your function. and the code window will open

    ![function name](images/function_eventgrid_name.png "function name")

1. Below is the code we will use to insert the events into Cosmos DB

    ```javascript
    module.exports = function (context, eventGridEvent) {        
        context.log(eventGridEvent);
        context.bindings.document = eventGridEvent.data;
        context.done();
    };
    ```

    ```csharp
    #r "Newtonsoft.Json"

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static void Run(JObject eventGridEvent, out object document, TraceWriter log)
    {
        log.Info(eventGridEvent.ToString(Formatting.Indented));
        log.Info(eventGridEvent["data"].ToString());    
        document = JObject.Parse(eventGridEvent["data"].ToString());  
    }
    ```


1. Now we can start using it. Click on the function app name

    ![function app](images/function_app.png "function app")

1. Click on the Application Insights link

    ![app insights](images/application_insights.png "app insights")

1. Click the Live Stream button

    ![app insights live stream](images/app_insights_live_stream.png "app insights live stream")

1. In a new window or browser tab, go to the container we created earlier for the storage account and click on the Upload link. You are also welcome to use a tool like [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)

    ![Upload blobs](images/storage_account_container_upload.png "Upload blobs")

1. Upload one or more files, at least a few with the .png extension

    ![Upload blob](images/storage_account_container_upload_blob.png "Upload blob")

1. Now let's watch the live streaming in Application Insights

    ![app insights live stream](images/app_insight_blobevents.png "app insights live stream")
