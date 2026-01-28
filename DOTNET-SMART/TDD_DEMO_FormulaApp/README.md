Steps to create the project:

dotnet new sln -o [name]
cd .. [name]

dotnet new webapi --use-controllers -n [name.api]
dotnet new xunit -n [name.unitTest]

dotnet sln add [name.api.csproj]
dotnet sln add [name.unitTest.csproj]
or
dotnet sln add **/*.csproj



[name.unitTest]
dotnet add reference [name.api.csproj]
dotnet add package Moq
    -mock created services and allow to inject into constructors
    -mimic DEPENDENCY INJECTION
dotnet add package FluentAssertions