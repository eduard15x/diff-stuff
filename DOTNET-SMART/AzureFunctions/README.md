# AZURE FUNCTIONS Demos & Examples

## Using Command Line

### Needed packages
* .net sdk >8
Azure Function CLI
* brew tap azure/functions
* brew install azure-functions-core-tools@4
* test by using command "func --version" (should be >4.)
Azure CLI
* INSTALL brew update && brew install azure-cli
* test by using command "az --version"
* UPDATE az upgrade
* UNINSTALL brew uninstall azure-cli
* REMOVE rm -rf ~/.azure

* AZURITE Extension VSC

### AZURITE EXTENSION VSC (for testing locally)
-open source emulator provides free local environment for testing your Azure Blog, Queue Storage and Table Storage applications.
-when everything works good locally, swith to using an Azure Storage Account in the cloud
-install Azurite Extension
-open Command Pallete

* Azurite: Clean - Reset all Azurite services persistency data
* Azurite: Clean Blob Service - Clean blob service
* Azurite: Clean Queue Service - Clean queue service
* Azurite: Clean Table Service - Clean table service
* Azurite: Close - Close all Azurite services
* Azurite: Close Blob Service - Close blob service
* Azurite: Close Queue Service - Close queue service
* Azurite: Close Table Service - Close table service
* Azurite: Start - Start all Azurite services
* Azurite: Start Blob Service - Start blob service
* Azurite: Start Queue Service - Start queue service
* Azurite: Start Table Service - Start table service

### Create New Azure Function Project
* func init "Azure-Function-Project-Name" --worker-runtime dotnet-isolated
* navigate to the project folder "cd Azure-Function-Project-Name"
* Create a new Azure Function (any template)

* I. func new --template "Http Trigger" --name "Desired-Function-Name" (it will automatically be added to .cspro)
* II.(manually) func new -> choose template -> choose name

### Start your project
* func start


### DEPLOY
* SING IN TO AZURE VIA CLI "az login"
* SELECT a new subscription via terminal after success login
* create resource group az group create --name AzureFunctionsQuickstart-rg --location <REGION>
* example: az group create --name AzureFunctionsDemo --location westeurope
* create a general-purpose storage account in your resource group and region
* az storage account create --name AzureFunctionsStorage --location westeurope --resource-group AzureFunctionsDemo --sku Standard-LRS --allow-blob-public-access false
* * ! (Standard_LRS specifies a general-purpose account)
* * Thee storage account is used to store important app data, sometimes including the application code itself. You should limit access from other apps and users to the storage account.
* create function app in Azure -> az functionapp create --resource-group AzureFunctionsDemo --consumption-plan-location westeurope --runtime dotnet-isolated --functions-version 4 --name AzureFunctionFirstDemo --storage-account AzureFunctionsStorage
* deploy the function project to azure
* func azure functionapp publish AzureFunctionFirstDemo
* view near real-time streaming logs -> func azure functionapp logstream <APP_NAME> (AzureFunctionFirstDemo in our case)
* * Clean up resources -> az group delete --name "ResourceGroupName"