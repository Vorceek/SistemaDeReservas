using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Aplication.Interfaces;
using SistemaDeReservas.Domain.Interfaces;
using SistemaDeReservas.Infraestructure.Entities;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userInterface = userService;


        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _userInterface.GetAllUser();
        }
    }
}
