CQRS = Command Query Responsability Segregration

* splitting "brain" in 2 parts: Commands & Queries

* Commands
    -doing actions
    -add to cart
    -update profile
    -write/update/delete operations

* Queries
    -asking questions
    -whats in my cart
    -read operations

* Reason
    -performance: focused concerns about optimization
    -scalability: commands and queries can be scaled independently, allowing for efficient handling of workloads
    -maintability: separating the concerns makes the code more modular and easier to understand
    -flexibility: different data stores and technologies can be used for reads and writes

* When to use
    -significant differences in read and write workloads
    -system needs to handle high traffic
    -complex business rules should be abstracted



** CQRS
    -divide a traditional layered architecture's CORE logic vertically, having now 2 different models (one dedicated for reads, one for write operations)
    -split the MODEL for reading and writing
    -born out of the Domain Driven Design (DDD movement)

** CORE CONCEPTS
    -Commands: actions that modify the system state
    -Queries: requests to retrieve data from the system
    -Write Model: Responsible for handling commands and updating the datastore
    -Read Model: Responsible for handling queries and retrieving data


** USE CASES
    1.Ecommerce
        -high volumes of product browsing (reads)
        -catalog is read optimized
        -order processing is write-heavy and complex

    2.Financial Systems
        -highly secure and audited write operations (transfers, deposits etc)
        -real time balance inquiries or statement generation

** WHEN NOT TO USE
    -most of the time
    -simple CRUD apps will be overkilled