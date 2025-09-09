# System Design for Frontend Developers

**Reference:** [Dmitriy Zhiganov - System Design for Frontend Developers](https://www.youtube.com/watch?v=zQ_wmJV8l44&ab_channel=DmitriyZhiganov)  
**Author:** Dmitriy Zhiganov

---

## What is System Design?

System design is a combination of practical experience and theoretical knowledge.  
In interviews, system design rounds assess your ability to architect scalable, maintainable, and robust systems.  
**Your performance in these rounds often determines your starting position and salary.**


---

## Frontend vs Backend System Design

| Frontend Focus                | Backend Focus                |
|-------------------------------|------------------------------|
| Smooth User Experience        | Scalability                  |
| Client/Server Communication   | Reliability                  |
| State Management              | Performance                  |

---

## Goals in System Design Interviews

- **Think in high-level abstractions:** Approach problems like a tech lead, not just a developer.
- **See the big picture:** Focus on the entire system, not just individual components.
- **Demonstrate breadth and depth:** Show both broad theoretical knowledge and deep domain expertise.
- **Consider trade-offs:** Always discuss pros and cons, not just optimistic scenarios.
- **Acknowledge downsides:** Be aware of the risks of third-party or external libraries.

**What to Avoid:**
- Focusing too much on implementation details.
- Getting stuck on specific tools or technologies.
- Only considering the "happy path" or positive scenarios.

---


## Typical System Design Interview Structure (45–60 min)

1. **Collecting Requirements**
    - Functional requirements (what the app must do)
    - Non-functional requirements (how the app should behave)
    - Out-of-scope items (what will not be covered)

2. **High-Level Architecture**
    - How do different parts interact?
    - What services are used and how many?
    - Which models/entities are connected?
    - Create a system blueprint before diving into details.
    - Ask clarifying questions to fully understand the goals.

  3. Data Modeling
    -which entities the system will use and interact with and how they relate to each other
    -

4. **Communication / API Design**
    - How does the server interact with the client?
    - What data is exchanged between frontend and backend (REST, GraphQL, WebSockets)?
    - Data formats (JSON, etc.), error handling, response structure, logging.

5. **Details / Additional Considerations**
    - Performance (critical)
    - Accessibility (critical)
    - Localization and translations
    - Offline-first strategies


---

## Practice: Example Apps for System Design

- **Facebook Feed (Meta):** Design a newsfeed with infinite scroll.
- **Google Calendar (Microsoft):** Scheduling system.
- **Checkout Payment System (Amazon)**
- **Flash Cards (Amazon)**
- **Music Streaming App (Meta)**
- **App Store (Apple)**
- **Video Streaming (Netflix)**

**How to Practice:**
- Design popular apps on your own, then seek feedback (e.g., from ChatGPT).
- Do mock interviews.
- Research company-specific questions and watch others' interviews.

**Platforms:**
- [interviewing.io](https://interviewing.io/)
- [Exponent](https://www.tryexponent.com/) (formerly Pramp)
- [Prepfully](https://www.prepfully.com/)
- ChatGPT

---


## Types of System Design Questions

1. **Frontend Design**
    - Deep dive into frontend details: performance, accessibility, localization.
    - Complex UI solutions (infinite scroll, efficient rendering).
    - Optimize rendering, reduce layout shifts, improve perceived performance.

2. **Frontend and API Design**
    - Focus on frontend and client-server communication.
    - Design APIs and model data for API responses.
    - Explain how frontend and backend interact (e.g., dashboard fetching data).

3. **Full Stack Design**
    - High-level design of the entire system (frontend + backend).
    - Provide an overview of both, focusing on their interaction.
    - Avoid going too deep due to time constraints.

---

## Understanding Requirements

**Clarify requirements before designing!**

1. **Functional Requirements (What must the app do?)**
    - Users can create and edit posts (e.g., social media app).
    - Users can listen to music and create playlists (music streaming).
    - Users can create meetings and share calendars (calendar app).

2. **Non-Functional Requirements (How should it work?)**
    - Fast performance, even on low-powered devices.
    - Safe and secure for users.
    - Support for downloading media files.

3. **Out-of-Scope**
    - Authorization/authentication (often too broad for a single interview).
    - SEO.
    - Localization (unless specifically requested).

---

## Developer Levels: Mindset Differences

| Middle Level Developer                        | Senior/Higher Level Developer                        |
|-----------------------------------------------|------------------------------------------------------|
| Focuses on the happy path                     | Considers trade-offs and alternatives                |
| Describes how to achieve requirements         | Explains pros/cons of solutions, offers alternatives |

---

## Interview Signals (Green/Red Flags)

**Green Flags:**
- Ask clarifying questions.
- Collaborate with the interviewer.
- Be honest about what you know and don't know.
- Clearly explain decisions, including pros and cons.

**Red Flags:**
- Jump straight into design without clarifying.
- Argue or ignore interviewer prompts.
- Pretend to have expertise you lack.
- Stay silent for long periods.

---

## Clarifying Questions (Based on Features)

- Do we need to support emerging markets (low bandwidth, older devices)?
- Does the app need to be localized and translated?
- For spreadsheets/feeds: How much data do we expect to receive?
- For real-time apps: How often does data need to update?
- For streaming platforms: Should users be able to download media files?

---

## Additional Tips

- **Always clarify requirements before starting your design.**
- **Think about edge cases and failure scenarios.**
- **Discuss trade-offs for every major decision.**
- **Focus on the user experience and business goals.**
- **Practice with real-world examples and get feedback.**

---

## Further Reading & Resources

- [System Design Primer](https://github.com/donnemartin/system-design-primer)
- [Frontend System Design Interview Guide](https://www.frontendinterviewhandbook.com/)
- [Designing Data-Intensive Applications](https://dataintensive.net/)
- [Awesome System Design](https://github.com/madd86/awesome-system-design)

---