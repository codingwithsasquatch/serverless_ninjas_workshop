# サーバーレス ロジックアップ ハンズオンラボ 

このラボでは、選択したキャラクターの情報を送信するロジックアップを作成します。

ロジックアプリは Cosmos DB を検索した後、キャラクターが存在を確認して、その有無に応じて処理を行います。メッセージは Cosmos DB に保存されユーザーに応答が戻ります。

![Logic App Diagram](images/Logic_App_Diagram.png "Logic App Diagram")

<b>このラボの開始前に、API Management とロジックアプリを 1 つ、[Logic App Lab Setup](LogicAppLabSetup.md) に沿って作ってください。</b>

## ラボのビデオ

以下のリンクからラボのウォークスルービデオが取得できます。

[![Logic App Demo Video](images/logic_app_lab_first_frame.png)](logic_app_lab.mp4)

## ロジックアプリの作成

1. Azure ポータルに接続。[https://portal.azure.com](https://portal.azure.com)

1. 「リソースの作成」をクリック。

    ![New Button](images/new_button.png "New Button")

1. 検索ボックスに "Logic App" と入力して候補を選択。

    ![Logic App](images/logic_app_search.png "Logic App")

1. 次の画面で Logic App を選択。

    ![Logic App](images/logic_app_result.png "Logic App")

1. 「作成」をクリック。

    ![Create](images/reate.png "Create")

1. 名前を設定し、既存のリソースグループを選択して「作成」をクリック。

    ![Create Logic App](images/create_logic_app.png "Create Logic App")

1. 作成が完了したら、通知より「リソースに移動」をクリック。

    ![Go to Logic App](images/goto_logic_app.png "Go to Logic App")

1. 「ロジック アプリ デザイナー」より「繰り返し」テンプレートを選択。

    ![Logic App Template](images/logic_app_template.png "Logic App Template")

Note: 繰り返しでロジックアプリが起動するため、ロジック起動のための追加の開発やソフトウェアの導入の必要がありません。

1. 繰り返しのインターバルを 1 分に変更。

    ![Logic App Template](images/logic_app_recurrence.png "Logic App Template")

1. 「新しいステップ」をクリック。

    ![Add Action](images/add_action.png "Add action")

1. JSON メッセージを保持するため変数を利用。検索ボックスに「変数」と入力。

    ![Logic App Variable](images/logic_app_variable_search.png "Logic App Variable")

1. アクションより「変数を初期化する」を選択。

    ![Logic App Variable](images/logic_app_initial_variable.png "Logic App Variable")

Note:  実際には HTTP トリガーの引数などで変数を受け取りますが、ここではロジックアプリ内で変数を作成しています。

1. 名前を入力して、種類より「文字列」を選択。

    ![Logic App Variable](images/logic_app_initial_variable_type.png "Logic App Variable")

1. 「値」に [CheatSheet.txt](CheatSheet.txt) より JSON 部分の値をコピー。

    ![Logic App Variable](images/logic_app_variable_body.png "Logic App Variable")

1. 名前と ID、カテゴリに最低 2 つ値を入力。まだデータベースにない、ユニークな値を設定。

    ![Logic App Variable](images/logic_app_initial_variable_values.png "Logic App Variable")

1. 「新しいステップ」をクリック。

    ![Add Action](images/add_action.png "Add action")

1. 検索ボックスに 「json の解析」と入力。

    ![Parse JSON](images/logic_app_parsejson_s.png "Parse JSON")

1. アクションより「JSON の解析」を選択。

    ![Parse JSON](images/logic_app_select_parse.png "Parse JSON")

1. コンテンツのテキストボックスを選択し、「動的なコンテンツ」より「charactermessage」を選択。

    ![Parse JSON](images/logic_app_parsejson_content.png "Parse JSON")

1. 「サンプルのペイロードを使用してスキーマを生成する」リンクをクリック。

    ![Parse Content](images/logic_app_sample_payload.png "Parse Content")

1. [CheatSheet.txt](CheatSheet.txt) より再度 JSON 部分をコピーして貼り付け、「完了」をクリック。

    ![Schema Editor](images/logic_app_parse_schema.png "Schema Editor")

1. 次に Cosmos DB の検索を追加。「新しいステップ」を選択。

    ![Add Action](images/add_action.png "Add action")

1. 検索ボックスに "cosmos" と入力。

    ![Search Cosmos DB](images/logic_app_cosmos_search.png "Search Cosmos DB")

1. アクションより「複数のドキュメントにクエリを実行する」を選択。

    ![Search Cosmos DB](images/logic_app_cosmos_result.png "Search Cosmos DB")

1. データベース ID とコレクションの設定。
   
    ![Search Cosmos DB](images/logic_app_cosmos_collection.png "Search Cosmos DB")

1. クエリに「SELECT * FROM c where c.name ='」と入力。

    ![Search Cosmos DB](images/logic_app_cosmos_select.png "Search Cosmos DB")

1. 検索条件に「動的なコンテンツ」より「name」を指定。

    ![Search Cosmos DB](images/logic_app_cosmos_name.png "Search Cosmos DB")

1. 最後にシングルクォーテーションを追加してクエリを完成。

    ![Search Cosmos DB](images/logic_app_cosmos_quote.png "Search Cosmos DB")

1. 「新しいステップ」を選択。

    ![New Step](images/new_step.png "New Step")

1. 「制御」をクリック。

    ![Add Condition](images/logic_app_add_condition.png "Add Condition")

1. 「条件」を選択。

    ![Add Condition](images/logic_app_add_condition_detail.png "Add Condition")

1. 「値の選択」で「動的なコンテンツ」より「_count」を選択。

    ![Add Condition](images/logic_app_condition_count.png "Add Condition")

1. 条件で「次の値以上」を選択し、値の選択で「１」を入力。

    ![Add Condition](images/logic_app_condition_value.png "Add Condition")

1. 「true の場合」で「アクションの追加」をクリック。

    ![Add Condition](images/logic_app_true_action.png "Add Condition")

1. 結果用のテキスト作成を行う。検索ボックスに「データ操作」と入力。

    ![Search Compose](images/logic_app_compose_search.png "Search Compose")

1. アクションより「作成」をクリック。

    ![Search Compose](images/logic_app_compose_results.png "Search Compose")

1. 入力テキストボックスに、「既にキャラクターが存在します」と入力。

    ![Compose](images/logic_app_compose.png "Compose")

1. 「false の場合」で「アクションの追加」をクリック。

    ![Add Condition](images/logic_app_false_action.png "Add Condition")

1. 「HTTP」を選択。

    ![HTTP](images/logic_app_http.png "HTTP")

1. アクションより HTTP を選択。

    ![Search Compose](images/logic_app_http_http.png "Search Compose")

1. 「方法」より「POST」を選択。

    ![POST](images/logic_app_http_post.png "POST")

1. ヘッダーの値に "Ocp-Apim-Subscription-Key" およびセットアップ時に取得したサブスクリプションキーを入力。※スペースが入らないように注意

    ![POST](images/logic_app_api_key_value.png "POST")

1. URL にセットアップで取得した API Management のベースおよびパスを指定。

    ![POST](images/logic_app_http_uri.png "POST")

1. 本文に「動的なコンテンツ」から「charactermessage」を指定。

    ![POST](images/logic_app_http_body.png "POST")

1. ロジックアプリを保存。

    ![Save Logic App](images/logic_app_save.png "Save Logic App")

1. 「実行」ボタンをクリック。

    ![Run Logic App](images/logic_app_run.png "Run Logic App")

1. 実行結果を確認。Cosmos DB に指定したキャラクターがいない場合作成される。

    ![Run Logic App](images/logic_app_finished.png "Run Logic App")
