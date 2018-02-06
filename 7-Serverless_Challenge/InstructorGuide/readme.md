# Serverless Ninjas Challenge - Instructor Guide

### Overview
A set of services have been provisioned to support this challenge:

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

### Source Code
The source code for the Functions can be found at: https://github.com/codingwithsasquatch/serverless_ninjas_workshop/tree/master/7-Serverless_Challenge/NinjaInventory.

### Tools
It would be helpful, but not necessary, if the participants can test the APIs with one of the following tools:
* Postman
* cURL
* Fiddler

### Guidelines
Some guidelines for the challenge include:
* Retrieve the list of products and assign each team a designed ID to work with for the challenge.
* Demonstrate how to call the APIs
* Provide the participants with the API key (header name is called-out in the challenge: x-functions-key).

### Sample Solution


### Resources
Postman Collection of requests:
[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/963b0f878b26ef54e7e2)
