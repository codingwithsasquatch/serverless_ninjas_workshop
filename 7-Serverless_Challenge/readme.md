# Serverless Ninjas Challenge

## Overview

Ninjas, LLC. would like to provide their partners with the ability to order products online. They have been given the directive to leverage the Serverless offerings in Azure as much as possible.

## Requirements

In this challenge, you are tasked with building a solution that helps launch this new offering. To support this endeavor, you will be given a set of APIs that will manage their inventory of products and must complete the remaining functionality.

The following requirements must be met to complete the challenge:

1) Provide an HTTP endpoint that can be used to place an order.

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

The solution can include any combination of Azure Functions, Logic Apps and Event Grid. Other services, such as Storage, might be included in order to complete the challenge. 

## APIs

A collection of APIs are provided to support the solution. Authorization is handled with an API key that can be passed into the header of each request. 

The proctor or instructor will provide the key at the time of the exercise.

1) Get details about a product (name and inventory count):

   * Method: GET
   * Headers: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/details/{id}
   * Example: https://ninjachallenge{challenge-number}.azurewebsites.net/api/details/2?code={api-key}
   * CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge{challenge-number}.azurewebsites.net/api/details/2

2) Restock a product:

   * Method: POST
   * Headers: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/add/{id}/{count}
   * Example: https://ninjachallenge{challenge-number}.azurewebsites.net/api/add/1/10?code={api-key}
   * CURL: curl -d "" -H "x-functions-key: {api-key}" -X POST https://ninjachallenge{challenge-number}.azurewebsites.net/api/add/1/10

3) Decrement the product count:

   * Method: POST
   * Headers: x-functions-key
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/remove/{id}/{count}
   * Example: https://ninjachallenge{challenge-number}.azurewebsites.net/api/remove/1/10?code={api-key}
   * CURL: curl -d "" -H "x-functions-key: {api-key}" -X POST https://ninjachallenge{challenge-number}.azurewebsites.net/api/remove/1/10

4) Get a list of products:

   * Method: GET
   * URL: https://ninjachallenge{challenge-number}.azurewebsites.net/api/list
   * Headers: x-functions-key
   * Example: https://ninjachallenge{challenge-number}.azurewebsites.net/api/list?code={api-key}
   * CURL: curl --header "x-functions-key: {api-key}" https://ninjachallenge{challenge-number}.azurewebsites.net/api/list

## Suggestions

* Consider the logical architecture first.
* Review the use cases and requirements before services and physical design of the solution.
* Leverage the strengths of each service.
* Use the provided APIs to manage the product inventory.

## References

* [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview "Azure Functions")
* [Logic Apps](https://docs.microsoft.com/en-us/azure/logic-apps/ "Azure Logic Apps")
* [Event Grid](https://docs.microsoft.com/en-us/azure/event-grid/overview "Azure Event Grid")

![serverless challenge](https://github.com/codingwithsasquatch/serverless_ninjas_workshop/raw/master/7-Serverless_Challenge/Ninja.jpg "Serverless Challenge")
