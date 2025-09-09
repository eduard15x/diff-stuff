# Frontend Architectural Patterns

**Reference:** [Dmitriy Zhiganov - 9+ Architectural Patterns](https://www.youtube.com/watch?v=ixee55xm_d8&ab_channel=DmitriyZhiganov)  
**Author:** Dmitriy Zhiganov

---

## Overview

This document summarizes and compares 9+ frontend architectural patterns, including MVC, MVP, MVVM, Clean Architecture, Hexagonal, VIPER, and more.  
**Key idea:** Frontend architecture is about how layers interact, not just about file and directory structure.

---

## Why Do We Need Architecture?

- **Flexibility:** Parts of the application can be replaced with minimal impact on others.
- **Testability:** Individual layers are easier to test in isolation.
- **Scalability:** Layer separation helps manage application growth.

**When is architecture important?**
- **Project Size:** Critical for large applications.
- **Team Size:** Becomes more important as teams grow.
- **Project Lifetime:** Essential for long-lived projects.

---

## Architectural Patterns

---

### 1. MVC (Model-View-Controller)

**Concept:**  
Three layers:
- **Model:** Application data and business logic.
- **View:** UI, responsible for presenting data.
- **Controller:** Handles state changes for View and Model.

#### Web MVC Example
- **Model:** Data Store (Redux, Vuex, Pinia, etc.)
- **View:** UI components (React, Vue, Angular)
- **Controller:** Hooks, composables

#### Full Stack MVC Example
- **Model:** Business rules and data
- **View:** React/Vue/Angular app
- **Controller:** API

#### Hierarchical MVC (for large apps)
- Large applications group small MVC apps together, each with its own state, view, and controller.
- **Model:** Its corresponding slice of state
- **View:** The page in React or Vue with its isolated self state
- **Controller:** Its domain API (e.g., `/dashboard`)

#### Thin & Thick Clients (SPAs, PWAs)
```
Web App → Client Storage → UI → Controller
Server App → Business Rules/DB → Web App → API
```

**Pros:**
- Easy to understand, develop, and maintain

**Cons:**
- "Fat" controllers
- Communication between modules can be unclear
- View layer may contain too much logic
- Legacy approach for modern web apps

---

### 2. MVP (Model-View-Presenter)

**Concept:**  
- Similar to MVC, but the Presenter sends data to the View (View only displays data).
- No direct updates from Model to View.
- In MVC, you have observables to keep data synced; in MVP, the Presenter manages this.

**Schema:**
```
Model <--> Presenter --> View
```

**Use Case:**  
When client-side logic is complex.

**Pros:**
- Clear layer separation
- Testable pure UI views

**Cons:**
- "Fat" presenter (can become a "god layer")
- Lacks a clear place for sync logic, API requests, etc.

---

### 3. MVVM (Model-View-ViewModel)

**Concept:**  
- Separates view logic from business logic.
- Suitable for applications with complex UI logic that need thorough testing.

**Business Logic Examples:**
- Change username
- Make a transaction
- Remove an item from basket

**View Logic Examples:**
- Open/close a modal
- Disable buttons
- Update download status

#### Two-Way Data Binding (e.g., Vue)
```
View --(DOM listeners)--> ViewModel --(methods)--> Model
View <--(directives)-- ViewModel <--(computed)-- Model
```

**Pros:**
- Clear separation: UI, business logic, presentation logic
- Scalable and testable

**Cons:**
- Steep learning curve
- Doesn't organize all concerns (e.g., API requests)

---

### 4. HMVC (Hierarchical MVC)

**Concept:**  
- Each MVC block is independent, adding modularity and scalability.
- Split by features, each with its own state/actions/listeners.

**Use Case:**  
Large-scale apps, multiple teams working on different features.

**Example (Angular):**
```
user/
  ├── user.module.ts      // module
  ├── user.component.ts   // view
  └── user.service.ts     // model
```

**Pros:**
- Modularity, independent development, improved testability
- Code reuse

**Cons:**
- Steep learning curve
- Inconsistency across modules

---

### 5. MVVM-C (Model-View-ViewModel-Coordinator)

**Concept:**  
- MVVM with a Coordinator layer for navigation and screen transitions.
- View does not handle navigation.

**Schema:**
```
View <--> ViewModel <--> Model
  |
Coordinator (handles navigation)
```

**Use Case:**  
Apps with complex navigation (e.g., multi-step wizards).

**Pros:**
- Clear separation of concerns
- Testable

**Cons:**
- Increased complexity

---

### 6. VIPER (View-Interactor-Presenter-Entity-Router) *(Mobile)*

**Schema:**
```
Router
  |
View → Presenter → Interactor
                    |
                 Entity
```

- **View:** Passive UI (user input/UI)
- **Interactor:** Business logic (fetches data from entity, requests backend)
- **Presenter:** Prepares data for View, sends requests to Interactor
- **Entity:** Data model (no business logic)
- **Router:** Handles navigation

**Pros:**
- Strong separation of concerns
- Scales well

**Cons:**
- More boilerplate (many interfaces)

---

### 7. Clean Architecture

**Layers:**
- **Entities:** Core business logic (rarely modified)
- **Use Cases:** Application-specific business rules
- **Interface Adapters:** Adapts inputs/outputs (e.g., entity → DTO)
- **Frameworks & Drivers:** UI, DB, external dependencies

**Schema:**
```
[Frameworks & Drivers] <--> [Interface Adapters] <--> [Use Cases] <--> [Entities]
```

**Principles:**
- Separate software into layers (entity and external interface layers are mandatory)
- Dependency rule: outer layers depend on inner layers, not vice versa

**Pros:**
- Highly testable
- Database and UI independent

**Cons:**
- High barrier to entry
- Increased complexity

---

### 8. Hexagonal Architecture (Ports and Adapters)

**Use Case:**  
Full-stack apps with complex business logic.

**Schema:**
```
DRIVING SIDE                BUSINESS LOGIC                DRIVEN SIDE
App UI, Console,      →   Input Port - Logic - Output Port   →   DB, Queue, HTTP
Testing Scripts
```
- **Driving Side:** UI, CLI, tests (initiates actions)
- **Business Logic:** Application core
- **Driven Side:** Databases, external APIs, queues

**Pros:**
- Decouples business logic from external systems
- Flexible and testable

**Cons:**
- More abstraction and setup

---

### 9. Screaming Architecture

**Concept:**  
- Architecture should make the business domain obvious at a glance (uses DDD).
- Organize by features/domains, not layers.

**Example:**
```
/users
/products
/orders
```
- **Frontend:** Pages (Users, Products)
- **Backend:** Services (Users, Products)

**Principles:**
- Top-level structure reflects business, not technical details
- Hide technical details in low-level modules

**Tip:**  
In system design interviews, focus on high-level architecture, not file organization.

---

### 10. Vertical Slices (Modern Approach)

**Concept:**  
- Feature-based approach: each feature is a business case, containing all its logic.

**Structure:**
```
Feature/
  ├── FeatureEntities
  ├── FeatureUseCases
  ├── FeatureControllers
  └── FeatureViews
```

**Comparison:**
- **Classic MVP:** One Presenter/Model for all features
- **Vertical Slices:** Separate Presenter/Model per feature (e.g., Create, Delete, Update Todo)

**Schema:**
```
Feature: CreateTodo
  - CreateTodoEntity
  - CreateTodoUseCase
  - CreateTodoController
  - CreateTodoView

Feature: DeleteTodo
  - DeleteTodoEntity
  - DeleteTodoUseCase
  - DeleteTodoController
  - DeleteTodoView
```

**Pros:**
- Better code organization: modular, self-contained features
- Easy for many teams to work independently

**Cons:**
- Potential for over-engineering
- Inconsistency (can be mitigated with guides, linters, code generation)

---

## Summary Table

| Pattern         | Pros                                      | Cons                                      | Best For                        |
|-----------------|-------------------------------------------|-------------------------------------------|----------------------------------|
| MVC             | Simple, maintainable                      | Fat controllers, legacy for web           | Small/medium web apps           |
| MVP             | Testable, clear UI logic                  | Fat presenter, lacks sync/API layer       | Complex client-side logic        |
| MVVM            | Clear separation, scalable                | Steep learning, not all concerns covered  | Complex UI, testable apps        |
| HMVC            | Modular, reusable                         | Steep learning, inconsistency             | Large, multi-team apps           |
| MVVM-C          | Separation, testable                      | Complexity                                | Complex navigation               |
| VIPER           | Separation, scalable                      | Boilerplate                               | Mobile, large-scale apps         |
| Clean Arch      | Testable, DB/UI independent               | Complexity, learning curve                | Long-lived, complex apps         |
| Hexagonal       | Flexible, decoupled                       | Complexity                                | Full-stack, complex logic        |
| Screaming Arch  | Business-focused, feature-oriented        | Needs discipline                          | DDD, business-driven apps        |
| Vertical Slices | Modular, team-friendly                    | Over-engineering, inconsistency           | Modern, feature-driven apps      |

---

## Further Reading

- [Clean Architecture by Uncle Bob](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Martin Fowler: Patterns of Enterprise Application Architecture](https://martinfowler.com/eaaCatalog/)
- [Domain-Driven Design (DDD)](https://domainlanguage.com/ddd/)
- [Hexagonal Architecture](https://alistair.cockburn.us/hexagonal-architecture/)

---