# USER SECRETS

## To create an user-secret hidden file use following commands in CLI

* dotnet user-secrets init -> initialize a user-secret hidden env file
* dotnet user-secrets list -> return all variables with their values
* dotnet user-secrets clear -> clear/remove all existing variables with their values
* dotnet user-secrets set "VariableName" "ValueName"
* dotnet user-secrets set "VariableName" "ValueName" --project "C:\apps\WebApp1\src\WebApp1"
