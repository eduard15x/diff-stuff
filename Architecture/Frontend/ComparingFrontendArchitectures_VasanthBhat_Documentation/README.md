# Frontend Architectures: A Comparison

*Based on Vasanth Bhat's presentation*  
[Reference Video](https://www.youtube.com/watch?v=bkr3s9thtUE&ab_channel=VasanthBhat)

---

## 1. Monolith Architecture

**Definition:**  
A monolith architecture is a traditional model where the entire application is built as a single, unified unit. All features, business logic, and UI are contained within one codebase, making it self-contained and independent from other applications.

**Advantages:**
- Easier continuous development and deployment.
- Reduced latency due to fewer network calls and tightly coupled components.
- Simple to set up and manage in the early stages.

**Disadvantages:**
- Becomes increasingly complex and difficult to scale as the application grows.
- Harder to adopt new technologies incrementally.
- A single change can require redeploying the entire application.

---

## 2. Micro-Frontends Architecture

**Definition:**  
Micro-frontends is an architectural style where a web application is divided into smaller, semi-independent "feature" apps, each owned by different teams. Each team is responsible for a distinct business domain and can choose its own tech stack.

**Example:**  
Large e-commerce platforms where different teams manage product listings, checkout, and user profiles independently.

**Advantages:**
- Enables teams to adopt different technology stacks as needed.
- Faster development and deployment cycles due to independent releases.
- Easier maintainability and scalability for large teams and projects.

**Disadvantages:**
- Potential for code duplication across teams.
- Extra effort required for code reviews, integration, and migrations.
- Increased complexity in orchestrating deployments and ensuring a consistent user experience.

---

## 3. Monorepo Architecture

**Definition:**  
A monorepo (monolithic repository) is a code management approach where all projects, libraries, and applications are stored in a single repository. This enables code sharing and unified tooling across multiple teams and projects.

**Examples:**  
Used by companies like Google, Facebook, Microsoft, and Uber.

**Typical Folder Structure:**
```
monorepo-root/
├── node_modules/
├── package.json
└── packages/
    ├── react-app-1/
    ├── react-app-2/
    ├── react-native-app-1/
    └── common/
```

**Popular Monorepo Tools:**
- [PNPM](https://pnpm.io/) / [Yarn Workspaces](https://classic.yarnpkg.com/en/docs/workspaces/)
- [Nx](https://nx.dev/)
- [Lerna](https://lerna.js.org/)

**Advantages:**
- Code and library reuse across projects.
- Faster code reviews and easier collaboration.
- Updating dependencies or lint rules across all projects is straightforward.
- Consistent tooling and configuration.

**Disadvantages:**
- No built-in way to restrict access to specific parts of the codebase.
- Too many packages can lead to longer bootstrap and install times.
- Git performance may degrade with very large repositories.
- Navigating a large folder structure can be slower and more complex.

---

## Summary Table

| Architecture      | Pros                                              | Cons                                                      |
|-------------------|--------------------------------------------------|-----------------------------------------------------------|
| **Monolith**      | Simple setup, low latency, easy early development | Hard to scale, difficult tech upgrades, large deployments |
| **Micro-frontends** | Tech flexibility, fast deployment, scalable teams | Code duplication, complex integration, review overhead    |
| **Monorepo**      | Code sharing, unified tooling, easy updates       | Access control, performance issues at scale, navigation   |

---

## Further Reading

- [Micro-Frontends](https://micro-frontends.org/)
- [Monorepo vs Polyrepo](https://monorepo.tools/)
- [Nx Documentation](https://nx.dev/)
- [Lerna Documentation](https://lerna.js.org/)

---