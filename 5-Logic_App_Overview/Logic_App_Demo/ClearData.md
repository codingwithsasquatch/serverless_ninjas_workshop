# Clean Up Demo Environment After Demo

## Clear Data from CosmosDB

This should be done before each demo.

1. Browse to the azure portal [https://portal.azure.com](https://portal.azure.com)

1. Go to the Data Explorer of you CosmosDB database.

   ![CosmosDB Data Explorer](images/cosmos_data_explorer.png "CosmosDB Data Explorer")

1. Right Click on collection name and select Delete Collection.

   ![CosmosDB Data Explorer](images/cosmos_delete_collection.png "CosmosDB Data Explorer")

1. Type in the name of the collection and select OK.

   ![CosmosDB Data Explorer](images/cosmos_delete_coll_name.png "CosmosDB Data Explorer")

1. Click "New Collection"

    ![Add Collection](images/cosmos_new_collection.png "Add Collection")

1. In the blade on the right hand side, give the database a name, the collection a name, and ensure that storage capacity is set to fixed.  Then press "OK".

    ![Add Collection](images/new_collection.png "Add Collection")