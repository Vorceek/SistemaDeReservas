using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Quartos;
using SistemaDeReservas.Application.Interfaces.Quartos;
using SistemaDeReservas.Application.Validators;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartoController : ControllerBase
    {
        private readonly IQuartoService _quartoService;
        private readonly IValidator<CreateQuartoDto> _validador;

        public QuartoController(IQuartoService quartoService, IValidator<CreateQuartoDto> validador)
        {
            _quartoService = quartoService;
            _validador = validador;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseQuartoDto>> GetAllQuarto()
        {
            return await _quartoService.GetAllQuarto();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseQuartoDto>> InsertAsync(CreateQuartoDto dto)
        {
            var erros = await _validador.ValidateAndBadRequestAsync(dto);
            if (erros != null) return (ActionResult)erros;

            return await _quartoService.InsertAsync(dto);
        }
    }
}
