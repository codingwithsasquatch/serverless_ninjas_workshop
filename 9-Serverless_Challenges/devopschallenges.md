# Serverless DevOps challenges

This challenges help you to configure development environment and add DevOps capability to your Serverless world. 


## Challenge 1. Building your local environment

Your project is getting very successful and popular, so new people are joining your team.
You need to create separate development environments to develop in parallel with your colleagues. 

### Requirement

 You need to setup your local development environment on your PC. You can choose to setup C# or Javascript based environment.  

### Success criteria

* You can run your function locally using Storage Emulator.
* You can debug your function locally with a break point.
* You can deploy your function to the Azure.

### Reference

* [Create your first function using Visual Studio](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio)
* [Create your first function using Visual Studio Code](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-function-vs-code)



## Challenge 2. CI/CD pipeline

Your team needs to share the code via private repository.Using Azure DevOps, set up the private repository with CI/CD pipeline.

## Requirement

Upload your code to Azure DevOps with a very simple unit tests. Once you submit a pull request, it starts build/test of the pull request's code automatically. Also, once you merge it to the master branch, it automatically build/test/deploy to Azure.

## Success criteria
     
* You can share the code via private repo.
* Your pull request triggers a CI pipeline with at least one unit test code.
* Automatically detects the change of master branch and triggers CI/CD pipeline for build/test/deploy to Azure.

### Reference 

* [Azure Repos Git Tutorial](https://docs.microsoft.com/en-us/azure/devops/repos/git/gitworkflow?view=vsts)
* [Serverless, DevOps, and CI/CD: Part 2](https://medium.com/microsoftazure/serverless-devops-and-ci-cd-part-2-b6e0a6d05530)
* [Azure Functions CI/CD pipeline for Node.js using VSTS](https://blogs.technet.microsoft.com/livedevopsinjapan/2017/12/13/azure-functions-cicd-pipeline-for-node-js-using-vsts/)

## Challenge 3. Run on container (Preview)

As your function is totally available, people from other division want to use it. However, they don't have access to Azure environment. They want to run your function on premise environment. You need to package your function in a Docker container.

## Requirement

Pack your function into a Docker container and run it on your local machine. Then share the container via DockerHub or Azure Container Registry. The final step is run it on Azure.

## Success criteria

* Your container works on your local machine as a docker container.
* Your image is uploaded to the DockerHub or Azure Container Registry.
* You are able to run the Docker container on Azure. 

You have three ways to run the Docker container in Azure:

1. Azure Functions
2. Azure Container Instances
3. Azure Kubernetes Services

### Reference 

* [Create a function on Linux using a custom image (preview)](https://docs.microsoft.com/en-au/azure/azure-functions/functions-create-function-linux-custom-image)
* [Quickstart: Create your first container in Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-quickstart-portal) 
* [Deploy a function to Kubernetes](https://github.com/Azure/azure-functions-core-tools#deploy-a-function-to-kubernetes)

