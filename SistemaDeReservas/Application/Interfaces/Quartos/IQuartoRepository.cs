using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Quartos
{
    public interface IQuartoRepository
    {
        Task<IEnumerable<Quarto>> GetAllAsync();
        Task<int> InsertAsync(Quarto quarto);
    }
}
