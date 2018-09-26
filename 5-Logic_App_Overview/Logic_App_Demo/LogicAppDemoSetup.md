# サーバーレス Logic App デモ環境セットアップ

セットアップ対象:  Azure ストレージアカウント、Cosmos DB、Azure Search
デモ実施の前に行ってください。

## Deployment テンプレートの更新

1. [deployment.json](deployment.json) ファイルをエディターで開く。

1. ファイルをローカルに保存。

## テンプレートを使用して、Azure ストレージアカウント、Cosmos DB およびファンクションを作成

1. Azure ポータルに接続。https://portal.azure.com
1.「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. 検索ボックスに "template" 入力し、候補より選択。

    ![Template](images/template_search.png "Template")

1. 次の画面で「テンプレートのデプロイ」を選択。

    ![Template Deployment](images/template_deployment_results.png "Template Deployment")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")

1. 「エディターで独自のテンプレートを作成する」をクリック。

    ![Build Template](images/template_build.png "Build Template")

1. 「ファイルの読込み」をクリック。

    ![Build Template](images/template_load_file.png "Build Template")

1. 先ほど保存した [deployoment.json](deployment.json) ファイルを指定。

    ![Build Template](images/template_json.png "Build Template")

1. 保存をクリック。

    ![Build Template](images/template_save.png "Build Template")

1. リソースグループなど変数に値を指定。使用条件に同意して「購入」をクリック。

    ![Build Template](images/template_settings.png "Build Template")

1. 展開が終わったら、通知より「リソースグループに移動」をクリック。

    ![Build Template](images/template_goto_resource.png "Build Template")

## ストレージアカウントのコンテナを作成

Logic App を起動するトリガーとしてファイルのアップロードを利用します。ここではそのためのストレージアカウントを設定します。

1. リソースグループに作成されたリソース一覧より、ストレージアカウント選択。
    ![Azure Storage Account](images/storage_account.png "Azure Storage Account")

1. BLOB をクリック。

    ![Azure Storage](images/storage_blob.png "Azure Storage")

1. 「コンテナー」をクリック。

    ![Create Storage Container](images/add_container.png "Create Storage Container")

1. 新しいコンテナー画面で、名前を指定し、「パブリックアクセスレベル」で「コンテナー (コンテナーと BLOB の匿名読み取りアクセス)」を選択して、「OK」をクリック。

    ![Storage Container](images/new_container.png "Create Storage Container")

1. [Azure ストレージエクスプローラー](https://azure.microsoft.com/en-us/features/storage-explorer/) をダウンロードしてインストール。

## Cosmos DB のコレクション作成

次にファイルアップロード後にメッセージを保存する Cosmos DB のコレクションを作成します。

1. リソースグループより Azure Cosmos DB アカウントを選択。

    ![Azure Cosmos DB](images/azure_cosmosdb.png "Azure Cosmos DB")

1. 「Overview」より「Add Collection」をクリック。

    ![Add Collection](images/add_collection.png "Add Collection")

1. データベース名、コレクション名を入力。ストレージの容量を Fix にして「OK」をクリック。

    ![Add Collection](images/new_collection.png "Add Collection")

## ファンクションの作成

1. リソースグループよりファンクション (App Service) を選択。

    ![Function](images/function.png "Function")

1. 「関数」の横にあるプラスをクリック。

    ![New Function](images/new_function.png "New Function")

1. 「カスタム関数を作成する」リンクをクリック。

    ![Create HTTP Function](images/create_your_own_function.png "Create HTTP Function")

1. 「HTTP Trigger」タイルで C# をクリック。

    ![Create HTTP Function](images/function_http_trigger.png "Create HTTP Function")

1. 名前を指定して「作成」をクリック。

    ![Create HTTP Function](images/function_properties.png "Create HTTP Function")

1. [attributemapfunction.txt](setup_data/attributemapfunction.txt) よりコードをコピーして、エディターにペースト後、保存。

    ![Add Function Code](images/function_code.png "Add Function Code")

## 統合アカウントの作成

1.  Azure ポータルに接続。https://portal.azure.com

1.「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. 検索ボックスに "integration account" と入力して候補から選択。

    ![Integration Account](images/integration_account_save.png "Integration Account")

1. 次の画面で「統合アカウント」を選択。

    ![Integration Account](images/logic_app_integration_account_result.png "Integration Account")

1. 「作成」をクリック。

    ![Create](images/create.png "Create")

1. 名前を指定し、既存のリソースグループを選択。「基本」価格レベルを選択して、「作成」をクリック。

    ![Integration Account](images/logic_app_new_integration_account.png "Integration Account")

1. 作成が終わったら、通知より「リソースに移動」をクリック。

    ![Go to Integration Account](images/integration_account_goto.png "Go to Integration Account")

1. 「マップ」タイルを選択。

    ![Maps](images/integration_account_maps.png "Maps")

1. 「追加」をクリック。

    ![Maps](images/integration_account_add_maps.png "Maps")

1. 名前を指定し、マップの種類で「Liquid」を指定。[TransformCharacters.liquid](setup_data/TransformCharacters.liquid) をローカルに保存して、「マップ」ファイルに指定。「OK」をクリックして作成。
   
    ![Maps](images/integration_account_add_liquid.png "Maps")

以上でデモ用のセットアップは完了です。
