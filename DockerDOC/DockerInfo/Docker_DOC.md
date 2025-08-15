# Docker Overview

Docker is a tool that helps you **develop, ship, and run applications** within lightweight containers.

---

## 🚀 Why Learn Docker?

- Widely used in tech companies
- Simplifies development & deployment
- Ensures your application works everywhere

---

## 📦 What Does Docker Package?

Docker allows you to package an application by wrapping its entire:
- Code
- Dependencies
- Libraries
- Environment settings
- Databases
- Caching
- Tools

You can bring or download a launchable package anywhere and run your application with confidence—no need to install dependencies manually; Docker handles it for you.

---

## 🧩 Important Docker Concepts

### Docker Image
- **Analogy:** Recipe that contains all ingredients and instructions
- Includes technologies, runtimes, tools, and instructions to run your code

### Docker Container
- **Analogy:** The actual meal made from the recipe
- One image can create multiple containers (replicas)

---

## 🛠️ How to Use Docker

1. **Download Docker Desktop**  
   [docker.com](https://www.docker.com/products/docker-desktop/)

2. **Check Docker Installation**
   ```sh
   docker --version
   ```

3. **Set Up Docker in Your IDE**
   - Install the Docker extension in Visual Studio Code

4. **Create a Dockerfile**
   - See the `NodejsServerWithDockerExample` project for reference

5. **Build an Image** (run from project root)
   ```sh
   docker build -t <name_of_docker_image> .
   ```
   - `-t`: Name of the Docker image
   - `.`: Path to the Dockerfile

6. **Run a Container**
   ```sh
   docker run -p 9000:9000 <name_of_docker_image>
   ```
   - `-p 9000:9000`: Port forwarding (host:container)

7. **Debugging**
   - Use Docker Desktop to check logs, stats, etc.

8. **Docker Scout**
   - Get recommendations and vulnerability summaries
   ```sh
   docker scout quickview
   ```

---

## 🧬 Docker Compose & Volumes

### Why Use Compose?
- For complex applications (backend, frontend, database, etc.)
- **Best Practice:** Separate each service into its own container (multi-container application)

### Problems Solved
- Running multiple containers together
- Connecting services

### Docker Compose Tool
- Defines how containers work together to form a full application
- See `compose.yaml` for examples

### Docker Volume
- Containers lose data when stopped; volumes persist data in local folders
- Allows multiple services to access shared data
- See volume usage in `compose.yaml`

---

## ☁️ Docker Build Cloud

- Speeds up builds for large applications by using the cloud
- Enables faster innovation and development cycles
- Check it on the google

---

## ⚡ Docker Init

- Quickly scaffolds all necessary Docker files for your project

---

## 📚 References

- [Official Docker Documentation](https://docs.docker.com/)
- See project examples:  
  - `NodejsServerWithDockerExample`
  - `compose.yaml`
