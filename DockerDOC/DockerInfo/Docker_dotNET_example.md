Containers
    - Includes everything needed by your app

Docker
    - A platform for packaging and running container-based apps
    - Ensures your app works the same way anywhere
    - Allows you to deliver software fast and consistenly across environments

Topics:
    -Why Docker Containers ?
    -Containers vs Virtual Machines
    -Getting started with Docker
    -Containers vs Images
    -Working with public images
    -Creating images via Dockerfiles
    -Creating images via .NET SDK
    -Image versioning
    -Publishing images
    -Containers in DevOps lifecycle


* Why Docker Containers?
Before virtualization
Scenario:
    Developer who has just finished a bug fixing or a feature and that needs to be deployed to production server
    Developer first send the binaries to the Ops Team (operations) followed by some instructions, and the Ops Team make changes for the server
    The production server, after deploy, it crashes
        -we need to check if the version of .NET on server is the same with the new one from developer
        -ensure the server uses the closes OS version
        -check if any required files are missing
        -maybe Ops Team missed a deployment step
        -not enough RAM/CPU on server
        -dependencies conflicts
        -missing permisions

These type of deployments are called "BARE METAL DEPLOYMENTS", because they start from the bottom
    -Hardware (CPU/RAM/DISK etc)  ->  Operating System + .NET Runtime version  ->  manual deployments of binaries file of .NET applications


Virtualizations
We start again from the bottom
    -Hardware
    -> * Hypervisor (resource manager - takes physical hardware and creates virtual versions of these instances, and VMs (virtual machines) use them) *

Benefits
    -OS/Runtime match (each VM can run isolately and have its own versions)
    -Clean environment
    -Better resource allocation
    -Built-in permissions
    -Easier to scale
    -Faster provisioning
    -Simpler rollback
Issues
    -Significant RAM/disk overhead
    -VM image creation pain (hours)
    -VM provisioning too slow
    -Boot time too slow
    -Multiple OS instances to patch
    -Hard to version control VM image

Containers: next level virtualization
We still starts from the bottom
    ->Hardware
    ->OS (instead of hypervisor)
        -kernel (core part of OS that directly controls the hardware: memory schedules, processes, talsk to devices)
        -user space (where apps and most system services live)
    -> Now, instead of virtualizing the entire OS (like we did in VMs), we have something called a Container Runtime (Docker) (works similar with a hypervisor, but more lightweight)
    -> Instead of creating entire virtual computers, it creates isolated spaces withing the existing OS, called containers, where apps can run
    -> Containers have: OS (the user space, in this case, UBUNTU), Runtime Environemnt (.NET / NodeJs), the APP itself
Benefits:
    -minimal resource overhead
    -near-instant image creation
    -fast provisioning
    -environment consistency
    -efficient resource usage
    -buil-in versioning

Combination: VMs + Containers
    -this hybrid approach is the best, like different cloud uses




Docker Images vs Containers

What docker image is? (blueprint)
    -what you normally do when you make a setup for a machine
        1.install OS
        2.install .NET runtime
        3.Copy app files
        4.Install dependencies
        5.Configure env
        6.Run app

    -to access it, you have to share it to a place where all devices can access it (container registry) (repository for docker images)

What container is? (running instance of an image)
    -isolated environment with its own file system processing all the configurations and setup

Downloading Container Images
    -work with existing working images
    -BIG REPOSITORY for existing images: https://hub.docker.com/  -> https://hub.docker.com/search?badges=official
    -example: docker pull nginx (thi will take latest version)
    -example: docker pull nginx:1.26.3 (this will take specific version)
    -example: docker pull nginx:stable (this will take specific version)

Docker TAGS
TAG                 My App Image
1.0                 Initial Release
1.1                 Security Patch
1.2                 Perf improvements
1.3                 CriticalFix             stable

2.0                 API rewrite             latest


Running Containers
    -how to run an image and turn it into a container
    -you have this commands in other doc files

Port mapping
    -host machine where we run a container which by default runs on port :80
    -we open browser and send request to :80 port, but we have an error because we didnt expose it from container outside
    -we need to create port mapping :8080 -> :80 (a bridge that redirects traffic to a specific) (a tunnel)
    -browser send request to :8080 and it successfully

Docker Volumes
    -Everytime you start a container it loses all its stored data, so for this one you will need -->> Docker Persistance Storage
    Docker Persistance Storage
Benefits
    -containers can be truly ephemeral
    -data can persists and be reused

    : docker run -d --rm -p 8080:80 -v nginx-data:/usr/share/nginx/html --name nginx-test nginx
    : docker volume list

    -> -v nginx-data:/usr/share/nginx/html -> will create a virtual volume to store data

Docker Image creation options:
    -dockerfile (text file where you set and configure the container)
    -.NET SDK

