FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet publish "dotnet-hello-docker.csproj" -o /publishedByDockerfile /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app

# COPY publishedDotnetApp/ ./ -> this is the initial setup when we create the publishedDirectory manually
# this will copy the published .NET application files into the working directory "app"

COPY --from=build /publishedByDockerfile .
# NEW: this will take the created directory from the "build" stage that we set at the beginning of the file

ENTRYPOINT [ "dotnet", "dotnet-hello-docker.dll" ]
