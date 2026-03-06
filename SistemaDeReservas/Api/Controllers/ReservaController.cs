using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Reservas;
using SistemaDeReservas.Application.Interfaces.Reservas;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController(IReservaService reservaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ResponseReservaDto>> GetAllReserva()
        {
            return await reservaService.GetAllReserva();
        }

        [HttpPost]
        public async Task<int> InsertAsync(CreateReservaDto reserva)
        {
            return await reservaService.InsertAsync(reserva);
        }
    }
}
