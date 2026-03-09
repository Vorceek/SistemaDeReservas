using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Hoteis;
using SistemaDeReservas.Application.DTOs.Reservas;
using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Application.Services;
using SistemaDeReservas.Application.Validators;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IValidator<CreateHotelDto> _validador;

        public HotelController(IHotelService hotelService, IValidator<CreateHotelDto> validador)
        {
            _hotelService = hotelService;
            _validador = validador;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseHotelDto>> GetAllHotel()
        {
            return await _hotelService.GetAllHotel();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseHotelDto>> InsertAsync(CreateHotelDto hotel)
        {
            var erros = await _validador.ValidateAndBadRequestAsync(hotel);
            if (erros != null) return (ActionResult)erros;

            return await _hotelService.InsertAsync(hotel);
        }
    }
}
