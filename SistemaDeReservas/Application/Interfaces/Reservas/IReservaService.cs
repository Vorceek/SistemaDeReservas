using SistemaDeReservas.Application.DTOs.Reservas;

namespace SistemaDeReservas.Application.Interfaces.Reservas
{
    public interface IReservaService
    {
        Task<IEnumerable<ResponseReservaDto>> GetAllReserva();
        Task<ResponseReservaDto> InsertAsync(CreateReservaDto dto);
    }
}
