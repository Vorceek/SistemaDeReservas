using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Application.DTOs.Hoteis;
using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Application.Services;

namespace SistemaDeReservas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController(IHotelService hotelService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ResponseHotelDto>> GetAllHotel()
        {
            return await hotelService.GetAllHotel();
        }

        [HttpPost]
        public async Task<int> InsertAsync(CreateHotelDto hotel)
        {
            return await hotelService.InsertAsync(hotel);
        }
    }
}
