using SistemaDeReservas.Application.DTOs.Reservas;
using SistemaDeReservas.Application.Interfaces.Reservas;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Services.Reservas
{
    public class ReservaService(IReservaRepository repository) : IReservaService
    {

        public async Task<IEnumerable<ResponseReservaDto>> GetAllReserva()
        {
            var reserva = await repository.GetAllAsync();
            return reserva.Select(r => new ResponseReservaDto
            {
                Id = r.Id,
                HotelId = r.HotelId,
                QuartoId = r.QuartoId,
                UserId = r.UserId,
                CheckIn = r.CheckIn,
                CheckOut = r.CheckOut
            });
        }

        public async Task<int> InsertAsync(CreateReservaDto dto)
        {
            var reserva = new Reserva
            {
                Id = Guid.NewGuid(),
                HotelId = dto.HotelId,
                QuartoId = dto.QuartoId,
                UserId = dto.UserId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut
            };
            return await repository.InsertAsync(reserva);
        }
    }
}
