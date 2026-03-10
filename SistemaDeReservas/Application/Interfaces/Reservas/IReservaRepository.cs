using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Reservas
{
    public interface IReservaRepository
    {
        Task<Reserva?> GetByIdAsync(Guid id);
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<int> InsertAsync(Reserva reserva);
    }
}
