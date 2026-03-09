using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Reservas;
using SistemaDeReservas.Application.Interfaces.Reservas;
using SistemaDeReservas.Application.Validators;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly IValidator<CreateReservaDto> _validador;

        public ReservaController(IReservaService reservaService, IValidator<CreateReservaDto> validador)
        {
            _reservaService = reservaService;
            _validador = validador;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseReservaDto>> GetAllReserva()
        {
            return await _reservaService.GetAllReserva();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseReservaDto>> InsertAsync(CreateReservaDto reserva)
        {
            var erros = await _validador.ValidateAndBadRequestAsync(reserva);
            if (erros != null) return (ActionResult)erros;

            return await _reservaService.InsertAsync(reserva);
        }
    }
}
