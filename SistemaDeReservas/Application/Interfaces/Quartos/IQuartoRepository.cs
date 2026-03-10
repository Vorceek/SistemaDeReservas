using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Quartos
{
    public interface IQuartoRepository
    {
        Task<Quarto?> GetByIdAsync(Guid id);
        Task<IEnumerable<Quarto>> GetAllAsync();
        Task<int> InsertAsync(Quarto quarto);
    }
}
