# Micro-Frontend Architecture

**Reference:** [Eric Tech - Micro-Frontend Architecture](https://www.youtube.com/watch?v=OmLsV8Dljzo&ab_channel=EricTech)  
**Author:** Eric Tech

---

## What is Micro-Frontend Architecture?

A **micro-frontend** is a microservice that exists within a browser.  
It applies the microservices concept to the frontend, allowing teams to independently develop, deploy, and maintain different parts of a web application.

---

## Traditional Approaches

- **Monolith:**  
  All code (frontend, backend, database) in a single repository and codebase.

- **Front + Back Separation:**  
  Separate repositories and codebases for frontend and backend.

- **Microservices:**  
  A frontend repository with a backend split into multiple microservices.

---

## Why Use Micro-Frontend Architecture?

For complex and large applications, micro-frontends enable **end-to-end teams** (e.g., Product, Checkout, Inspire) to own and manage their features independently.

- **Divides responsibilities** into multiple browser-based parts.
- **Each micro-frontend** has its own codebase and responsibility.

**Benefits:**

- **Scalability:** Teams can work and deploy independently.
- **Reusability:** Components and features can be reused across teams.
- **Reliability:** Failure in one micro-frontend does not crash the entire app.
- **Technology Flexibility:** Teams can use different frameworks (React, Angular, Vue, etc.).

**Example Team Structure:**

- **Product Team:** Product MFE + Product microservice
- **Cart Team:** Cart MFE + Cart microservice
- **Transaction Team:** Transaction MFE + Transaction microservice

---

## Disadvantages

- **Excessive Coupling:** Risk of tightly coupled micro-frontends if not managed well.
- **Increased Costs:** More infrastructure and coordination
