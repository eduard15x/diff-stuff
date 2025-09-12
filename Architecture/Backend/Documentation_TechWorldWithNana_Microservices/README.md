# Microservices Architecture

**Reference:** [TechWorld with Nana - Microservices Architecture](https://www.youtube.com/watch?v=rv4LlmLmVWk&ab_channel=TechWorldwithNana)  
**Author:** TechWorld with Nana

---

## What is Microservices Architecture?

Microservices architecture splits an application into smaller, independent services. Each service is self-contained, loosely coupled, and responsible for a specific business functionality.

---

## Key Questions

1. **How to break down the application?**
2. **What code goes where?**
3. **How many services do we create?**
4. **How big/small should a microservice be?**
5. **How do microservices communicate with each other?**

---

## Principles of Microservices

- **Business-Oriented Splitting:**  
  Split the application based on business functionalities, not technical layers.
- **Separation of Concerns:**  
  Each service should do one specific job.
- **Self-Contained & Independent:**  
  Services are loosely coupled and can be built, deployed, and scaled independently.
- **Versioning:**  
  Each microservice can have its own version.

---

## Communication Between Microservices

1. **API Calls (Synchronous Communication)**
    - Each service exposes its own API.
    - Services communicate by sending requests to each other's API endpoints.

2. **Message Broker (Asynchronous Communication)**
    - Common patterns: Publish/Subscribe, Point-to-Point messaging.
    - Decouples services and enables event-driven architectures.

3. **Service Mesh (e.g., Kubernetes)**
    - Uses a proxy (sidecar pattern) at the network level.
    - A helper service manages all communication logic between microservices.

---

## Downsides & Challenges

- **Increased Complexity:**  
  Microservices introduce distributed system challenges (e.g., network configuration, data consistency).
- **Monitoring:**  
  Harder to monitor multiple instances of each service distributed across servers.
- **Deployment & Scaling:**  
  Deploying and scaling services independently can be complex.

---

## CI/CD Pipeline for Microservices

- Large organizations deploy hundreds of microservices thousands of times per day.
- CI/CD pipelines must handle independent builds, tests, and deployments for each service.

---

## Monorepo vs Polyrepo for Microservices

### Monorepo

- **Single Git repository** containing all services/projects (each in its own directory).
- **Advantages:**
    - Easier code management and development.
    - Shared code is simple.
- **Disadvantages:**
    - Harder to create pipelines that identify changes for a single service and deploy/test only that service.

### Polyrepo

- **One repository per service** (code is isolated).
- **Advantages:**
    - Each service has its own pipeline.
    - Clear isolation and independent deployments.
- **Disadvantages:**
    - No shared files; code duplication is likely.
    - In platforms like GitLab, you can group repositories for better management and shared secrets.

---

## Further Learning

- Explore CI/CD best practices for microservices.
- Learn about service discovery, distributed tracing, and monitoring in microservices environments.
- Study patterns for handling data consistency and transactions