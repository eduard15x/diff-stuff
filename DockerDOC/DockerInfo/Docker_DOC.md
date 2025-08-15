Docker
-a tool that helps you develop, ship and run applications within lighweight containers

Why should we know docker?
-lot of tech companies use Docker
-makes development & deployment easier

Docker allows you to package an application by wrapping its entire:
    -code
    -dependencies
    -libraries
    -environment settings
    -databases
    -caching
    -tools

You can bring/download launchable anywhere for everyone and run you application (you are sure it works.)
You don't need to install anything... docker does it for you when you run it

IMPORTANT DOCKER CONCEPTS
-Images
-Containers

* Docker Image (recipe that contains all ingredients and condiments)
    -technologies we need
    -runtimes
    -tools/instructions to run the code

* Docker Container (actual meal made from the recipe)
    -one image can create multiple containers (replicas)


How to use docker?
1. Download it (docker.com -> download Docker Desktop)
2. Check if you have docker
    -open terminal
    -type docker --version
3. Set Up docker on IDE (download docker extension in VSC)
4. Dockerfile CREATION (important) (please see project NodejsServerWithDockerExample) for refference
5. IMAGE BUILD (run from root of the project)
    -command: docker build -t "name_of_docker_image" .
    : -t (name of docket image)
    : . (patch of Dockerfile)
6. CONTAINER RUN
    -command: docker run -p 9000:9000 "name_of_docker_image"
    : -p 9000:9000 (port forwarding - network configuration technique that allows external devices to access services on a private network)
    : -p 9000:9000 BRIDGE -> computer (number on left) - container (number on the right)
7. DEBUGGING (easier from Docker Desktop) (you can check logs, stats etc)
8. Docker Scout (when you build the image, docker gave you a recommendation)
    -command: docker scout quickview (summary of image vulnerabilities and recommendations)

nodejs_server_test_docker_eduard