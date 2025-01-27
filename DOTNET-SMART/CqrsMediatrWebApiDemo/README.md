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