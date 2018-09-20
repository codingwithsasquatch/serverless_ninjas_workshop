# Serverless DevOps challenges

This challenges help you to configure development environment and add DevOps capability to your Serverless world. 


## Challenge 1. Building your local environment

As your success of the serverless architecture adoption, several people is joining your team. 
You need to have separate development environment with your colleague to develop in parallel. 

### Requirement

 You need to setup your local development environment on your PC. You can choose C# or Javascript  

### Success criteria

* You can run your function locally using Storage Emulator
* You can debug your function locally with a break point
* You can push your function to the Azure

### Reference

* [Create your first function using Visual Studio](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio)
* [Create your first function using Visual Studio Code](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-vs-code)



## Challenge 2. CI/ CD pipeline

Your team need to share the code with your colleague to a private repository. Using Azure DevOps, set up the private repository with CI/CD pipeline

## Requirement

Upload your code to the Azure DevOps with a very simple unit test code. Once you submit a pull request, it start build/test your pull request automatically. Also, once you check in to the master, it automatically build/test/deploy to Azure.

## Success criteria
     
* You can share the code in a private repo
* Your pull request triggs a CI pipeline with at least one unit test code.
* Automatically detect the change of master branch, triggs CI/CD pipeline to build/test/deploy to Azure.

### Reference 

* [Azure Repos Git Tutorial](https://docs.microsoft.com/en-us/azure/devops/repos/git/gitworkflow?view=vsts)
* [Serverless, DevOps, and CI/CD: Part 2](https://medium.com/microsoftazure/serverless-devops-and-ci-cd-part-2-b6e0a6d05530)
* [Azure Functions CI/CD pipeline for Node.js using VSTS](https://blogs.technet.microsoft.com/livedevopsinjapan/2017/12/13/azure-functions-cicd-pipeline-for-node-js-using-vsts/)

## Challenge 3. Run on container (Preview)

As your function is totally available, people from other division want to use it. However, they don't have Azure environment. They required it works on premise environment. You need to run your function locally on container. 

## Requirement

Pack your function into docker container and run on your local machine with sharing on DockerHub or Azure Container Registry then run on Azure

## Success criteria

Your container works on your local machine as a docker container
Your image is uploaded to the DockerHub or Azure Container Registry
Run the docker container on Azure 

NOTE: You have three ways to run this. Azure Functions, Azure Container Instances, Azure Kubernetes Services

### Reference 

* [Create a function on Linux using a custom image (preview)](https://docs.microsoft.com/en-au/azure/azure-functions/functions-create-function-linux-custom-image)
* [Quickstart: Create your first container in Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-quickstart-portal) 
* [Deploy a function to Kubernetes](https://github.com/Azure/azure-functions-core-tools#deploy-a-function-to-kubernetes)

