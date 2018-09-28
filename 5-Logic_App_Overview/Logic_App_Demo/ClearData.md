# デモ環境のデータ削除

## Cosmos DB のデータ削除

デモを行う前に、毎回以下手順でデータを削除してください。

1. Azure ポータルに接続。https://portal.azure.com

1. リソースグループより Cosmos DB を選択し、「Data Explorer」を選択。

   ![CosmosDB Data Explorer](images/cosmos_data_explorer.png "CosmosDB Data Explorer")

1. コレクションを右クリックして「Delete Collection」をクリック。

   ![CosmosDB Data Explorer](images/cosmos_delete_collection.png "CosmosDB Data Explorer")

1. コレクション名を入力して「OK」をクリック。

   ![CosmosDB Data Explorer](images/cosmos_delete_coll_name.png "CosmosDB Data Explorer")

1. 「New Collection」をクリック。

    ![Add Collection](images/cosmos_new_collection.png "Add Collection")

1. 「Add Collection」画面で、「Database id」と「collection Id」 を指定してコレクションを再作成。

    ![Add Collection](images/new_collection.png "Add Collection")
