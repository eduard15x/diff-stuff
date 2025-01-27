# CQRS and MediatR in .NET (Mediator Pattern)

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


