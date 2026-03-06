using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Application.Validators;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserDto> _validador;

        public UserController(IUserService userService, IValidator<CreateUserDto> validador)
        {
            _userService = userService;
            _validador = validador;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseUserDto>> GetAllUser()
        {
            return await _userService.GetAllUser();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseUserDto>> InsertAsync(CreateUserDto user)
        {
            var erros = await _validador.ValidateAndBadRequestAsync(user);
            if (erros != null) return (ActionResult)erros;

            return await _userService.InsertAsync(user);
        }
    }
}
