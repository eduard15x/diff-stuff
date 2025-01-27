# CQRS and MediatR in .NET (Mediator Pattern)

!!! TODO
add notification to manage multiple handlers (when you create an entity send a notification to another handler)
https://codewithmukesh.com/blog/cqrs-and-mediatr-in-aspnet-core/?utm_source=reddit

https://github.com/codewithmukesh/dotnet-zero-to-hero-advanced-course

* CQRS (command query responsability segregation) and the Mediator Pattern
* MediatR Implementation
* Requests with MediatR
* MediatR Commands
* MediatR Notifications
* MediatR Behaviors

## Info
- Usually we find the application having an API architecture based on CRUD operations, and these all operations are handled by the data store service when it receive a request
- With CQRS patterns does splitting these operations in (Query for READ) and (Commands for CREATE/UPDATE/DELETE)

## Nuget Packages Needed
* MediatR

# Before MediatR
![BeforeCQRSandMediatR](https://github.com/user-attachments/assets/39da22fc-286a-4679-a551-532fc5cd07b6)



# After MediatR
![CQRSandMediatR](https://github.com/user-attachments/assets/88c0a756-1e2f-41ec-94d4-6914dea8d128)


# MediatR explained
![MediatR-in-details](https://github.com/user-attachments/assets/d533e7cb-5b0f-45a0-9abb-9a90974546d4)


# no CQRS vs CQRS
![noCQRSvsCRQS](https://github.com/user-attachments/assets/ed9f5407-5924-49bc-80c2-c38de78c54cc)


