# Docker CLI Commands

## 🐳 Docker Basics

### Check Docker Version
```sh
docker --version
```

### Docker Commands Help
```sh
docker --help
```

---

## 📋 List Commands

### List all containers (including stopped)
```sh
docker ps -a
```

### List all running containers
```sh
docker ps
```

### List all images
```sh
docker images
```

---

## 🗑️ Remove Commands

### Stop a container
```sh
docker stop <container_id_or_name>
```

### Force remove a container (even if it's running)
```sh
docker rm -f <container_id_or_name>
```

### Remove an image (container must be deleted first)
```sh
docker rmi <image_id_or_name>
```

### Force remove an image
```sh
docker rmi -f <image_id_or_name>
```

### Remove all stopped containers
```sh
docker container prune
```

### Remove all unused images
```sh
docker image prune
```

### Remove everything unused (containers, networks, images, build cache)
```sh
docker system prune
```

---

## ⏹️ Stop Commands

### Stop a container (detached mode or another terminal)
```sh
docker stop <container_id_or_name>
```

### Stop a container running in foreground
Press `CTRL + C`

---

## 🚀 Run Commands

### Build an image based on Dockerfile
```sh
docker build -t <image_name> .   # '.' is the path to the Dockerfile
```

### Run a container
```sh
docker run -p 9000:9000 nodejs_server_test_docker_eduard
```

### Run a container in detached mode (background)
```sh
docker run -d -p 9000:9000 nodejs_server_test_docker_eduard
```

## Logs

## View Container Logs
```sh
docker logs <container_id_or_name>
```



## Official Documentation
* https://docs.docker.com/reference/cli/docker/