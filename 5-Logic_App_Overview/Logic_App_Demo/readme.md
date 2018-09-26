# サーバレス Logic App デモ

このデモは Logic App の説明中に利用するものです。データは異なるものの、このデモは実際のシナリオに基づいた実装となります。

以下の Logic App はマーベル社のデータベースにあるキャラクターの一覧をアップロードします。リストは JSON ドキュメントであり、キャラクターの特性を記したテキストファイルです。

ファイルがアップロードされると、各キャラクターのデータは Cosmos DB に格納され、その後 ”Ninja” というキーワードで検索が行われます。

![Logic App Diagram](images/logic_app_overview.png "Logic App Diagram")

<b>少なくとも [Logic App デモのセットアップ](LogicAppDemoSetup.md) を一度は行ってから、このデモを試してください。同じデモを試す場合は、Cosmos DB のデータを [データの削除手順](ClearData.md) から消去してから行ってください。</b>

## デモのビデオ

以下のリンクよりデモのビデオがダウンロードできます。

[![Logic App Demo Video](images/logicappdemo_first_frame.png)](LogicAppDemo.mp4)

## Azure ストレージエクスプローラー

このデモでは [Azure ストレージエクスプローラー](https://azure.microsoft.com/en-us/features/storage-explorer/) を使います。必須ではありませんが是非利用してください。ツールにログインする際は、環境構築で使ったアカウントを利用してください。

## Logic App の作成
1. Azure ポータルに接続。 [https://portal.azure.com](https://portal.azure.com)
1. 「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. 検索ボックスに "Logic App" と入力して候補から選択。

    ![Logic App](images/logic_app_search.png "Logic App")

1. 次の画面で Logic App を選択。

    ![Logic App](images/logic_app_result.png "Logic App")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")

1. 名前を指定し、リソースグループを指定。場所を選択して、「作成」をクリック。

    ![Create Logic App](images/create_logic_app.png "Create Logic App")

1. 作成が完了したら、通知より「リソースに移動」をクリック。

    ![Go to Logic App](images/goto_logic_app.png "Go to Logic App")

1. Logic App デザイナーが開くが、統合アカウントを利用の設定をまず行うため、上部のリンクより作成した Logic App の名前をクリック。統合アカウントについては [統合アカウントのドキュメント](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-enterprise-integration-create-integration-account) を参照。

    ![Workflow Settings](images/logic_app_breadcrumb.png "Workflow Settings")

1. メニューより「ワークフロー設定」をクリック。

    ![Workflow Settings](images/logic_app_workflow_settings.png "Workflow Settings")

1. 設定画面より、「統合アカウント」の欄で、セットアップで作成したアカウントを指定。

    ![Integration Account](images/logic_app_integration_account.png "Integration Account")

1. 「保存」をクリック。

    ![Save](images/save.png "Save")

1. 「ロジック アプリ デザイナー」をクリック。

    ![Logic App Template](images/logic_app_designer_tab.png "Logic App Template")

1. 「ロジック アプリ デザイナー」から様々なテンプレートを利用可能。ここでは「空のロジックアプリ」テンプレートから作成。

    ![Logic App Template](images/logic_app_template.png "Logic App Template")

### Azure ストレージアカウント BLOB トリガー

1. デザイナーが開くと、トリガーの選択が表示されるので、「blob」を検索。

    ![Logic App Trigger](images/logic_app_blob_search.png "Logic App Trigger")

1. トリガーより「Azure Blob Storage」を選択。

    ![Logic App Trigger](images/logic_app_select_blob.png "Logic App Trigger")

1. 接続名を入力して、セットアップで作成したストレージアカウントを選択。「作成」をクリック。

    ![Logic App Trigger](images/logic_app_blob_create.png "Logic App Trigger")

1. 「コンテナー」項目の右側にあるフォルダーアイコンをクリックし、作成済のコンテナを指定。間隔は既定の 3 分のままにしておく。

    ![Logic App Trigger](images/logic_app_blob_container.png "Logic App Trigger")

### Azure ストレージのコンテンツ取得

作成したトリガーは Blob コンテナーにアイテムがアップロードされた事だけが通知されるため、コンテンツは別途取得する必要があり〼。

1. 「新しいステップ」をクリック。

    ![Add Action](images/add_action.png "Add action")

1. 検索ボックスに blob と入力して検索。

    ![Logic App Action](images/logic_app_blob_search.png "Logic App Action")

1. 「アクション」より「BLOB コンテンツの取得」を選択。

    ![Logic App Action](images/logic_app_get_blob_content.png "Logic App Action")

1. BLOB 欄をクリックして、動的なコンテンツより「ファイルの一覧 Path」を選択。動的なコンテンツを利用すると、これまでのステップで得た値が選択可能。

    ![Logic App Action](images/logic_app_blob_path.png "Logic App Action")

### JSON ファイルのパース

JSON のパースは Logic App でよく利用されるアクションで、パースされたプロパティは以降のアクションで利用が可能になります。

1. 「新しいステップ」をクリック。

    ![Add Action](images/add_action.png "Add action")

1. 検索ボックスに json と入力して検索。「データ操作」をクリック。

    ![Parse JSON](images/logic_app_parsejson_s.png "Parse JSON")

1. アクションより「JSON の解析」を選択。

    ![Parse JSON](images/logic_app_select_parse.png "Parse JSON")

### Expression Editor    

入力データは JSON フォーマットですが、受信したデータの型は JSON 文字列ではないため、「式」の機能で変換します。

1. 「コンテンツ」テキストボックスをクリック。右側に出るメニューより「式」タブをクリック。

    ![Parse Content](images/logic_app_expression.png "Parse Content")

1. 「変換関数」にある「json(value)」を選択。

    ![Expression](images/logic_app_expression_json.png "Expression")

1. 「動的なコンテンツ」タブをクリックして、「ファイルのコンテンツ」を選択。「OK」をクリック。

    ![Dynamic Properties](images/locic_app_json_dynamic_content.png "Dynamic Properties")

1. 次にスキーマのテキストボックス下部にある「サンプルのペイロードを使用してスキーマを生成する」をクリック。これで実際のデータからスキーマを自動生成可能。

    ![Parse Content](images/logic_app_sample_payload.png "Parse Content")

1. [sampleschema.json](setup_data/sampleschema.json) の中身を張り付けて、「完了」をクリック。

    ![Schema Editor](images/logic_app_parse_schema.png "Schema Editor")
    
1. スキーマが生成されることを確認。

    ![Schema Editor](images/logic_app_schema_parsed.png "Schema Editor")

## データを Cosmos DB に送信

データの取得をした次は、結果を Cosmos DB に保存します。データはファンクションを使って分割してから格納します。

### ファンクションの追加。

1. 「新しいステップ」をクリック。

    ![Add Action](images/add_action.png "Add action")

1. 検索ボックスで azure function を検索。

    ![Azure Function](images/logic_app_azure_function_search.png "Azure Function")

1. アクションより「Azure 関数を選択する」をクリック。

    ![Azure Function](images/logic_app_select_function.png "Azure Function")

1. ファンクションの一覧が表示されるため、事前に作成したファンクションを選択。

    ![Azure Function](images/logic_app_select_specific_function.png "Azure Function")

1. アクションの下で利用する関数をクリック。

    ![Azure Function](images/logic_app_function_format_attributes.png "Azure Function")

1. 「要求本文」をクリックして、「動的コンテンツ」より「text」を選択。

    ![Azure Function](images/logic_app_function_body.png "Azure Function")

1. 自動的に「For each」コンテナが作成される事を確認。

    ![Azure Function](images/logic_app_foreach.png "Azure Function")

### Liquid マップ

JSON ドキュメントのプロパティはこれで取得できました。次に作成済のマップを利用して必要なデータを取得します。

1. 「For each」の一番下にある「アクションの追加」をクリック。

    ![Add Action](images/logic_app_foreach_action.png "Add Action")

1. 検索ボックスで liquid を検索。

    ![Liquid](images/logic_app_liquid_search.png "Liquid")

1. アクションから「JSON を JSON に変換」を選択。

    ![Liquid](images/logic_app_liquid_json_json.png "Liquid")

1. マップのドロップダウンより、作成済の統合アカウントよりマップを選択。

    ![Liquid](images/logic_app_map.png "Liquid")

### コードビュー

GUI から選択が困難な場合、コードビューを利用して直接コードを記述することが出来ます。

1. 「JSON を JSON に変換」アクションの「コンテンツ」を選択した後、画面上部にある「コードビュー」をクリック。

    ![Code View](images/logic_app_code_view.png "Code View")


1. 「JSON_を_JSON_に変換」項目を探して、input -> content の値を以下のコードに差し替え。

```logic app code
@addProperty(items('For_each'), 'attributes', body('FormatAttributes'))
```

![Code View](images/logic_app_transform_content.png "Code View")

1. 「デザイナー」をクリックして元の画面に戻る。

    ![Designer](images/logic_app_designer.png "Designer")

### Cosmos DB 接続

1. 「For each」の一番下で「アクションの追加」をクリック。

    ![Add Action](images/logic_app_foreach_action.png "Add Action")

1. 検索ボックスで cosmos と入力。

    ![CosmosDB](images/logic_app_cosmos_search.png "CosmosDB")

1. アクションより「ドキュメントを作成または更新する」を選択。

    ![CosmosDB](images/logic_app_cosmos_create_doc.png "CosmosDB")

1. 接続名を入力して、一覧より事前に作成した Cosmos DB を選択。「作成」をクリック。

    ![CosmosDB](images/logic_app_cosmos_select_db.png "CosmosDB")

1. 「データベース ID」と「コレクション ID」を選択。

    ![CosmosDB](images/logic_app_cosmos_values.png "CosmosDB")

1. 「ドキュメント」のテキストボックスをクリックして、「変換後のコンテンツ」を選択。

    ![CosmosDB](images/logic_app_cosmos_data.png "CosmosDB")
    
以上で Logic App の開発は終わりです。

## デモの実行

1. Logic App を保存。

    ![Save Logic App](images/logic_app_save.png "Save Logic App")

1. 保存したらデザイナーを閉じる。

    ![Close Logic App](images/logic_app_close.png "Close Logic App")

1. Azure ストレージエクスプローラーを開いて、作成したストレージアカウントを開く。

    ![Azure Storage Explorer](images/storage_explorer_browse.png "Azure Storage Explorer")

1. Blob Containers を展開してコンテナーを選択。

    ![Azure Storage Explorer](images/storage_explorer_container.png "Azure Storage Explorer")

1. [Characters.json](demo_data\characters.json) ファイルをローカルにコピーしてアップロード。

    ![Azure Storage Explorer](images/azure_storage_explorer_upload.png "Azure Storage Explorer")

1. Log App の画面に戻って「トリガーの実行」より「BLOB が追加または更新された時」をクリック。

    ![Run Logic App](images/logic_app_run_trigger.png "Run Logic App")

1. 「最新の情報に更新」をクリック。

    ![Run Logic App](images/logic_app_refresh.png "Run Logic App")

1. 履歴で「成功」が出るまで更新。

    ![Run Logic App](images/logic_app_run_history.png "Run Logic App")

1. 成功のログをクリックして詳細を確認。成功したステップは緑のチェックが表示され、中身も確認可能。

    ![Run Logic App](images/logic_app_run_details.png "Run Logic App")

1. Cosmos DB に接続して、「Data Explorer」より以下クエリにてデータを確認。

```sql
SELECT * FROM c WHERE ARRAY_CONTAINS(c.Attributes.Category, 'Ninjas')
```
