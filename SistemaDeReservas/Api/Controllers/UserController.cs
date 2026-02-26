using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<UserResponseDto>> GetAllUser()
        {
            return await userService.GetAllUser();
        }

        [HttpPost]
        public async Task<int> InsertAsync(CreateUserDto user)
        {
            return await userService.InsertAsync(user);
        }
    }
}
