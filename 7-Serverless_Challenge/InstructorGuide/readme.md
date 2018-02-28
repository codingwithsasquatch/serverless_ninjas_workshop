# Serverless Ninjas Challenge - Instructor Guide

This guide provides a reference for the proctors and instructors of the [Serverless Challenge](https://github.com/codingwithsasquatch/serverless_ninjas_workshop/tree/master/7-Serverless_Challenge). 

It is recommended that the attendees of the workshop break up into teams to collaborate on the solution. Each team will require access to a resource group with the Contributor role.

----
## Directions

1. Refer attendees to the [Serverless Challenge](https://github.com/codingwithsasquatch/serverless_ninjas_workshop/tree/master/7-Serverless_Challenge). Walk through the requirements and address any questions.

2. Provide the necessary key for the API calls: https://aka.ms/serverlesscontentkeys

3. Demonstrate how to retrieve the list of products using Postman, Fiddler, cURL or your tool of choice. Highlight the API key in the header and how to apply it. Examples:

       URL: GET https://ninjachallenge.azurewebsites.net/api/list?code={api-key}
       CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge.azurewebsites.net/api/list

4. Break attendees up into teams and assign them a dedicated API (ninjachallenge{number}.azurewebsites.net) to work with.

5. Solicit help from proctors during the challenge.

----
## Resources
The following services have been provisioned to support the challenge:

* CosmosDB database
  * Endpoint: https://ninjachallenge.documents.azure.com:443/
  * Database ID: inventory
  * Collection ID: products     
  
* Azure Functions
  * URL: https://ninjachallenge.azurewebsites.net 
  * Init - Initializes the database, collection and data (https://ninjachallenge.azurewebsites.net/api/init)
  * Add - Increments the count (https://ninjachallenge.azurewebsites.net/api/add/{id}/{count})
  * Remove - Decrements the count (https://ninjachallenge.azurewebsites.net/api/remove/{id}/{count})
  * Details - Gets the details for a product by ID (https://ninjachallenge.azurewebsites.net/api/details/{id})
  * List - Gets all products (https://ninjachallenge.azurewebsites.net/api/list)

The API key can be appended to the URLs or added to the header of each request.

* Query string example: https://ninjachallenge.azurewebsites.net/api/list?code={api-key}
* Header name: x-functions-key

Attendees do not need to make any changes to the services, they will just call the APIs to work with the inventory of products.

Postman collection for proctors and instructors:

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/963b0f878b26ef54e7e2)

----
## Source Code
The source code for the Functions can be found at: https://github.com/codingwithsasquatch/serverless_ninjas_workshop/tree/master/7-Serverless_Challenge/NinjaInventory.

Application settings required for the Function App:

| Setting                 | Value                       | 
| ------------------------|:----------------------------| 
| DocumentDbAuthKey       | {CosmosDB Read-Write Key}   | 
| DocumentDbCollectionId  | products                    | 
| DocumentDbEndpoint      | {CosmosDB Endpoint}         | 
| DocumentDbDatabaseId    | inventory                   | 

----
## Recommended Tools
* Postman
* cURL
* Fiddler
* Cloud Shell (https://shell.azure.com/ or within the Azure Portal)
