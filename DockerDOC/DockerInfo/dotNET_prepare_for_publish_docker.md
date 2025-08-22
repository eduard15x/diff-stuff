.NET SDK
after you have the project run:
    -dotnet publish dotnet-hello-docker.csproj -o publishedDirectory -> will create it with an executable program

    -!!!*dotnet publish dotnet-hello-docker.csproj -o publishedDirectory /p:UseAppHost=false* -> now you can run this app in multiple environments on different OS


Dockerfile
    -Create the docker file configuration

Building a Docker Image
    -Open CLI
    -docker build -t hello-docker-name .(location-of-docker-file)  (based on the dockerfile)

Run the image in container
    -docker run --rm -p 8080:8080 [docker-image-name]

Multi-stage Builds
    -we can configure Dockerfile to automatically builds the published directory for our app
    -add .dockerignore
    -check new Dockerfile config

Create new Docker Image Versions
    -rename the actual version of latest to "initial-release" or "1.0"
    CLI: docker tag hello-dotnet-docker:latest hello-dotnet-docker:1.0
    -after you update the code, create new image with specific version
    CLI docker build -t hello-dotnet-docker:1.1 .

Create smaller size images
    -check the images in repository for a specific version, maybe choose another OS like alpine instead debian
    -instead of [FROM mcr.microsoft.com/dotnet/aspnet:8.0] change to [FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine]

Building docker images with .NET SDK
    -dotnet publish --os linux --arch x64 /t:PublishContainer -p ContainerImageTag=1.3
    -you can modify you .csproj file if you want to create another image with some specific configs



***

Publishing images in the container registry (repository for images that can acces your image and download it)
    -Public registry (docker hub)
    -Private registries (need credentials)

Publish with Docker CLI in dockerhub (hub.docker.com)
    -docker tag hello-dotnet-docker:1.2 eduard15x/hello-dotnet-docker:1.2
    -docker push eduard15x/hello-dotnet-docker:1.2

Publishing with .NET CLI
    -add this line in .csproj: <ContainerRepository>eduard15x/hello-dotnet-docker</ContainerRepository>
    -dotnet publish --os linux --arch x64 -p ContainerRegistry=docker.io /t:PublishContainer -p ContainerImageTag=1.3

Running a Container in Cloud
    -or another laptop, pull down the uploaded image on docker.hub
    -go to: docker.com/play-with-docker (find labs environment)
    -add new instance
    -it will open a terminal
    -docker run -p 8080:8080 eduard15x/hello-dotnet-docker:1.2