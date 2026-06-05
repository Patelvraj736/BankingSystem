# BankingSystem

Lightweight banking system implemented in C# on .NET 10. The solution follows a layered architecture (API, Application, Domain, Infrastructure) and includes unit tests.

## Quick summary
- Languages: C# targeting .NET 10
- Patterns: MediatR handlers, unit-of-work, repository, factories, EF Core for persistence

## Prerequisites
- .NET 10 SDK
- `dotnet` CLI on PATH
- Optional: Visual Studio or VS Code

## Quick start
1. Restore and build:

   `dotnet restore`

   `dotnet build`

2. Apply EF Core migrations (if needed):

   `dotnet ef database update --project BankingApplication.Infrastructure --startup-project BankingApplication.Api`

3. Run API:

   `dotnet run --project BankingApplication.Api`

4. Run tests:

   `dotnet test`

## Selected files by layer (short task)

- `BankingApplication.Api`
  - `Program.cs` - host and DI setup
  - `appsettings.json` - configuration and connection strings
  - `Controllers/AccountController.cs` - account endpoints
  - `Controllers/TransactionController.cs` - transaction endpoints
  - `Controllers/CustomerController.cs` - customer endpoints
  - `Controllers/LoanController.cs` - loan endpoints

- `BankingApplication.Application`
  - `Handler/*Handler.cs` - implement use-cases via MediatR (create account/customer, deposit, withdraw, transfer, apply loan, queries)
  - `Command/*Command.cs` - command DTOs for actions
  - `Query/*Query.cs` - query DTOs (e.g., transaction history)
  - `Dtos/*` - response DTOs
  - `Validators/*Validator.cs` - input validation rules
  - `Interfaces/IUnitOfWork.cs` and repository interfaces - application-level contracts

- `BankingApplication.Domain`
  - `Entities/*` - domain models (Account, SavingAccount, CurrentAccount, Customer, Transaction, Loan, BaseEntity, AuditEntity)
  - `Enums/*` - domain enums (AccountType, TransactionType, LoanStatus)
  - `AccountFactory/*` - account factories and provider interfaces

- `BankingApplication.Infrastructure`
  - `Data/AppDbContext.cs` - EF Core DbContext and entity configuration
  - `Repositories/*Repository.cs` - repository implementations and generic repository
  - `Repositories/UnitOfWork.cs` - concrete unit-of-work
  - `Migrations/*` - EF Core migrations

- `BankingApplication.Tests`
  - `Handlers/*Tests.cs` - unit tests for handlers (create customer/account, deposit, withdraw, transfer, apply loan, transaction history)

## Common commands
- Build: `dotnet build`
- Run API: `dotnet run --project BankingApplication.Api`
- Run tests: `dotnet test`
- Migrations: `dotnet ef database update --project BankingApplication.Infrastructure --startup-project BankingApplication.Api`

## Contributing
Contributions are welcome. Open an issue or submit a pull request.

## License
MIT (add `LICENSE` file if missing).
