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

        public async Task<ResponseReservaDto> InsertAsync(CreateReservaDto dto)
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
            
            await repository.InsertAsync(reserva);
            return new ResponseReservaDto
            {
                Id = reserva.Id,
                HotelId = reserva.HotelId,
                QuartoId = reserva.QuartoId,
                UserId = reserva.UserId,
                CheckIn = reserva.CheckIn,
                CheckOut = reserva.CheckOut
            };
        }
    }
}
