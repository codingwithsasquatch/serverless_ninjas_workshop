# サーバーレス NINJA チャンレジ

## 概要

Ninjas, LLC. はパートナー向けにオンラインで商品を販売したいと考えています。また開発にあたり Azure のサーバーレスソリューションを極力使うよう指示が出ています。

## 要件

このチャレンジでは上記概要を満たすソリューションを開発します。開発にあたり、必要となる API や商品情報が提供されます。

チャンレジを完了するには以下の要件を満たす必要があります。

1) 商品の発注ができる以下 HTTP エンドポイントの提供

   * リクエスト本文のサンプル:

         {
            "id": "2",
            "count": 2,
            "customerid": "1000",
            "email": "customer@contoso.com"
         }

2) 発注が作成されたら、在庫の引き当てをします。

3) 電子メールでパートナーに発注を受領した旨を伝えます。

   * 在庫がある場合は 5 営業日以内に発送する旨を伝えます。
   * 在庫が不足している場合は、10 営業日以内に発送する旨を伝えます。

4) もし在庫が少なくなった場合、商品の仕入れ処理を自動で行います。

ソリューションは Azure Functions、ロジックアプリ、およびイベントグリッドを自由に組み合わせて使ってください。また必要に応じて Azure ストレージ等他のサービスも利用してください。

## API

ソリューションをサポートするための API が提供されます。認証は API キーを HTTP 要求ヘッダーに設定する必要があります。
インストラクターおよびメンターが当日キーの情報を提供します。

1) 商品の詳細を取得 (名前と在庫数)

   * HTTP メソッド: GET
   * ヘッダー: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/details/{id}
   * 例: https://ninjachallenge{challenge-number}.azurewebsites.net/api/details/2?code={api-key}
   * CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge{challenge-number}.azurewebsites.net/api/details/2

2) 在庫の補充:

   * HTTP メソッド: POST
   * ヘッダー: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/add/{id}/{count}
   * 例: https://ninjachallenge{challenge-number}.azurewebsites.net/api/add/1/10?code={api-key}
   * CURL: curl -d "" -H "x-functions-key: {api-key}" -X POST https://ninjachallenge{challenge-number}.azurewebsites.net/api/add/1/10

3) 在庫の引き当て:

   * HTTP メソッド: POST
   * ヘッダー: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/remove/{id}/{count}
   * 例: https://ninjachallenge{challenge-number}.azurewebsites.net/api/remove/1/10?code={api-key}
   * CURL: curl -d "" -H "x-functions-key: {api-key}" -X POST https://ninjachallenge{challenge-number}.azurewebsites.net/api/remove/1/10

4) 商品一覧の取得:

   * HTTP メソッド: GET
   * ヘッダー: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/list
   * 例: https://ninjachallenge{challenge-number}.azurewebsites.net/api/list?code={api-key}
   * CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge{challenge-number}.azurewebsites.net/api/list

## ヒント

* 論理アーキテクチャをまず検討する。
* サービスやソリューションのアーキテクチャを検討する前に、ユースケースと要件を確認する。
* 各サービスの強みを活用する。
* 提供された API を使って在庫を管理する。

## 参照

* [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview "Azure Functions")
* [Logic Apps](https://docs.microsoft.com/en-us/azure/logic-apps/ "Azure Logic Apps")
* [Event Grid](https://docs.microsoft.com/en-us/azure/event-grid/overview "Azure Event Grid")

![serverless challenge](https://github.com/codingwithsasquatch/serverless_ninjas_workshop/raw/master/7-Serverless_Challenge/Ninja.jpg "Serverless Challenge")
