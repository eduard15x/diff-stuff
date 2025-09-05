# Monorepo Architecture  
*Based on Rohan Prasad's presentation*  
[Reference Video](https://www.youtube.com/watch?v=6LoqigJpifg&ab_channel=RohanPrasad)

---

## 1. What is a Monorepo?

A **monorepo** (short for "monolithic repository") is a single repository that stores all of your code and assets for multiple projects. This approach has been used by large companies like Google for years. It is often confused with **monolithic** architectures (where all code is tightly coupled) or **multi-repo** setups (where each project has its own repository).

**Key characteristics:**
- All code (server, UI, mobile apps, shared libraries, etc.) lives in a single repository.
- Projects inside the monorepo are isolated from each other but share the same codebase.
- Common configuration files (e.g., for linting, formatting, or build tools) can be shared across projects.
- Dependency management tools like **Yarn Workspaces** or **pnpm** (with **Turborepo**) help manage packages and dependencies efficiently.

---

## 2. Advantages

- **Visibility:** Developers can easily see and understand how other projects work, fostering collaboration and knowledge sharing.
- **Unified Tooling:** Shared configuration for tools like ESLint, Prettier, and TypeScript ensures consistency across all projects.
- **Shared Libraries:** Components, utilities, and libraries can be reused across projects without publishing to external registries.
- **Simplified Dependency Management:** Projects can depend on each other directly, reducing the need for separate NPM packages or third-party dependencies.
- **Atomic Changes:** Large-scale refactoring or updates can be made across all projects in a single commit.

---

## 3. Disadvantages

- **Visibility:** Lack of access control—every developer can see all projects, which may not be desirable for sensitive code.
- **Increased Complexity:** Managing a large codebase with many projects can become complex, especially as the number of contributors grows.
- **Slower Build Times:** As the repository grows, build and test times can increase, potentially slowing down development workflows.
- **Tooling Overhead:** Requires robust tooling and automation to manage builds, tests, and deployments efficiently.

---

## 4. Build Tools

Several tools are available to help manage monorepos, each with its own strengths:

- **BUCK** (by Meta): Focused on fast builds and scripts.
- **BAZEL** (by Google): Highly scalable, supports multiple languages and platforms.
- **RUSH** (by Microsoft): Manages monorepos with many NPM packages, focusing on large teams and projects.
- **LERNA:** Simplifies publishing, dependency management, and building for JavaScript/TypeScript monorepos.  
  - [Lerna Introduction](https://lerna.js.org/docs/introduction)
  - [Lerna Video Guide](https://www.youtube.com/watch?v=hRe-_GCMfYQ&ab_channel=JamesHenry)
- **YARN WORKSPACES:** Native monorepo support in Yarn for managing dependencies and linking packages.
- **PNPM + TURBOREPO:** Fast, disk-efficient package management and advanced build orchestration.

---

## 5. When to Use a Monorepo

- When you have multiple related projects that share code or dependencies.
- When you want to enforce consistent tooling and standards across projects.
- When you need to coordinate changes across several projects simultaneously.

---

## 6. When Not to Use a Monorepo

- When projects are completely unrelated or have different release cycles.
- When access control and code separation are critical.
- When your team lacks the resources to manage the added complexity.

---

## Further Reading

- [Monorepo vs. Polyrepo](https://monorepo.tools/)
- [Google's Monorepo Philosophy](https://opensource.googleblog.com/2017/02/why-google-stores-build-tools-in.html)
- [Turborepo Documentation](https://turbo.build/)

---