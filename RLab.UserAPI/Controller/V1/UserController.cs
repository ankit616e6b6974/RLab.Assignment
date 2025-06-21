using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace RLab.UserAPI.Controller.V1
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
    }
}


//├── UserManagement.API          // ASP.NET Core Web API (Presentation Layer)
//├── UserManagement.Application  // Business Logic Layer (Use Cases, DTOs)
//├── UserManagement.Domain       // Core Entities, Interfaces, Enums
//├── UserManagement.Infrastructure // DB context, EF Core Repositories
//├── UserManagement.Shared
