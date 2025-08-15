# Docker & Kubernetes Overview

## Docker

Docker is a platform that lets you build, package, and distribute applications in isolated environments called **containers**.

### What is a Docker Container?

A single shipping container that packages everything your app needs to run:

- Code
- Dependencies
- System libraries
- System tools
- Runtime

### Docker Workflow

1. **Dockerfile**  
   A text file that describes how to build your container.  
   - Defines base image (e.g., Python, Node.js)
   - Installs dependencies
   - Copies files
   - Runs commands

2. **Docker Image**  
   The result of building a Dockerfile.  
   - Contains everything needed to run your app: code, libraries, tools, etc.

3. **Docker Container**  
   A running instance of a Docker image.  
   - Can be run on any device with Docker installed
   - Enables consistent environments for development, staging, and production

---

## Kubernetes

Kubernetes is a container orchestration platform.  
Think of it as an entire port that manages thousands of shipping containers.

### Why Kubernetes?

- Manages containers across multiple machines
- Handles scaling, load balancing, and self-healing
- Provides features Docker alone cannot handle at scale

### Key Concepts

- **Pod**:  
  The smallest unit in Kubernetes.  
  - Groups one or more Docker containers
  - Containers in a pod share the same network and storage
  - Ideal for tightly coupled applications that need to communicate

---

## How Do Docker and Kubernetes Work Together?

- **Docker**: Builds, packages, and runs containers.
- **Kubernetes**: Orchestrates and manages containers at scale.

Once you have containers, Kubernetes manages them across clusters of machines, handling deployment, scaling, and
