using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Quartos;
using SistemaDeReservas.Application.Interfaces.Quartos;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController(IQuartoService quartoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ResponseQuartoDto>> GetAllQuarto()
        {
            return await quartoService.GetAllQuarto();
        }

        [HttpPost]
        public async Task<int> InsertAsync(CreateQuartoDto dto)
        {
            return await quartoService.InsertAsync(dto);
        }
    }
}
