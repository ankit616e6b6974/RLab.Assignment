## Overview

This project demonstrates a **modular and testable .NET-based architecture** with clear separation of concerns across multiple layers:

- **Core**, **DTO**, **Infrastructure**, and **Interface** layers follow clean architecture principles.
- External user data is fetched from a public API using a resilient service layer.
- API behavior is exposed through **Swagger UI** for demo, validation, and manual testing.

Developers can interact with and test API endpoints directly via Swagger, including:
- Fetching single users by ID
- Paginated user listing

---

## 📁 Project Structure

| Project             | Responsibility                                                                 |
|---------------------|---------------------------------------------------------------------------------|
| **RLab.Core**       | Core domain entities and constants                                              |
| **RLab.DTO**        | Data Transfer Objects (DTOs) for API contracts and serialization                |
| **RLab.Interface**  | Interfaces and abstractions used across services, mappers, etc.                 |
| **RLab.Infrastructure** | Implementation of services (e.g., `ExternalUserService`), exceptions, extensions |
| **RLab.UserAPI**    | Web API layer, exposes endpoints to clients via controllers                    |
| **RLab.UnitTest**   | NUnit test project covering service and controller logic using FluentAssertions |

---

## 🚀 Getting Started

### 🧱 Prerequisites

- [.NET 6 SDK or newer](https://dotnet.microsoft.com/en-us/)
- IDE like Visual Studio 2022 or VS Code
- Internet access (for API calls to [ReqRes](https://reqres.in))

---

### 🛠️ Build the Solution

```bash
dotnet restore
dotnet build
```

Make sure all projects reference each other correctly via project references (especially `Infrastructure`, `Core`, and `Interface` layers).

---

### ✅ Running Tests

Navigate to the test project directory and run:

```bash
dotnet test RLab.UnitTest
```

Test coverage includes:
- Service-level tests mocking `HttpMessageHandler`
- Controller-level tests (optional) with simplified or integrated mocks
- Validation scenarios (like null/empty input checks)

---

### 🧪 ExternalUserService Highlights

- Uses `HttpClientFactory` with named clients (`ReqResClient`)
- Handles external API calls gracefully via `SafeSendAsync()` and `SafeReadFromJsonAsync()`
- Maps third-party responses to internal domain models via `IUserMapper`
- Returns consistent `ApiResponse<T>` for all service calls

---

### 🎯 API and Controller Layer (`RLab.UserAPI`)

- Follows REST conventions using ASP.NET Core controllers
- Wraps responses using consistent `ApiResponse<T>` format
- Automatically validates and handles bad inputs with proper responses

---

## 🧱 Design Decisions

- **Separation of Concerns**: Clean architecture with interface-first development
- **Testability**: No hardcoded dependencies; everything is DI-ready and mockable
- **Resilience**: All HTTP calls are wrapped in safe extension methods
- **DTO/Entity Separation**: External formats are mapped to internal models for consistency
