# Serverless Ninjas Challenge

### Overview

Ninjas, LLC. would like to provide their partners with the ability to order products online. They have been given the directive to leverage the Serverless offerings in Azure as much as possible. 

### Requirements
In this challenge, you are tasked with building a solution that helps launch this new offering. To support this endeavor, you will be given a set of APIs that will manage their inventory of products and must complete the remaining functionality.

The following requirements must be met to complete the challenge:

1) Provide an HTTP endpoint that can be used to place an order.
   * Provide some level of security to avoid anonymous calls to the endpoint
   * Sample request body:
   
         {
            "id": "2",
            "count": 2,
            "customerid": "1000",
            "email": "customer@contoso.com"
         }

2) After an order is placed, decrement the inventory count. 

3) Notify the partner, with an email, that the order has been received. 
   * If there is enough inventory to fulfill the order, notify them that it will be shipped within 5 business days.
   * If there is not enough inventory to fulfill the order, notify them that it will be shipped within 10 business days.
   
4) If the inventory count for a product is low, initiate a process that will restock the product. 

The solution can include any combination of Azure Functions, Logic Apps and Event Grid. 

###  APIs
The following APIs are available to support the solution. 

Note: The API Key will be provided at the time of the exercise.

1) Get details about a product (name and inventory count): 
   * URL: https://ninjachallenge.azurewebsites.net/api/details/{id}
   * Example: https://ninjachallenge.azurewebsites.net/api/details/2
   * CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge.azurewebsites.net/api/details/2
   
2) Restock a product: 
   * POST https://ninjachallenge.azurewebsites.net/api/add/{id}/{count}
   * Example: https://ninjachallenge.azurewebsites.net/api/add/1/10
   * CURL: curl -d "" -H "x-functions-key: {api-key}" -X POST https://ninjachallenge.azurewebsites.net/api/add/1/10
   
3) Decrement the product count: 
   * POST https://ninjachallenge.azurewebsites.net/api/remove/{id}/{count}
   * Example: https://ninjachallenge.azurewebsites.net/api/remove/1/10
   * CURL: curl -d "" -H "x-functions-key: {api-key}" -X POST https://ninjachallenge.azurewebsites.net/api/remove/1/10
   
4) Get a list of products: 
   * GET https://ninjachallenge.azurewebsites.net/api/details/{id}
   * Example: https://ninjachallenge.azurewebsites.net/api/details/2
   * CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge.azurewebsites.net/api/details/2

### Suggestions
* Consider the logical architecture first. 
* Think about the workflow, use cases and requirements before choosing the services and physical architecture for the solution.
* Leverage the strengths of each service.
* Use the provided APIs to manage the product inventory.

### References
* [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview "Azure Functions")
* [Logic Apps](https://docs.microsoft.com/en-us/azure/logic-apps/ "Azure Logic Apps")
* [Event Grid](https://docs.microsoft.com/en-us/azure/event-grid/overview "Azure Event Grid")

![alt text](https://github.com/codingwithsasquatch/serverless_ninjas_workshop/raw/master/7-Serverless_Challenge/Ninja.jpg "Serverless Challenge")
