using SistemaDeReservas.Application.DTOs.Hoteis;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Services.Hoteis
{
    public class HotelService(IHotelRepository repository) : IHotelService
    {
        public async Task<IEnumerable<ResponseHotelDto>> GetAllHotel()
        {
            var hotel = await repository.GetAllAsync();
            return hotel.Select(h => new ResponseHotelDto
            {
                Id = h.Id,
                Nome = h.Nome,
                Cnpj = h.Cnpj
            });
        }

        public async Task<ResponseHotelDto> InsertAsync(CreateHotelDto dto)
        {
            var hotel = new Hotel
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cnpj = dto.Cnpj
            };
            await repository.InsertAsync(hotel);
            return new ResponseHotelDto
            {
                Id = hotel.Id,
                Nome = hotel.Nome,
                Cnpj = hotel.Cnpj
            };
        }
    }
}
