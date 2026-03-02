using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Hoteis
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<int> InsertAsync(Hotel hotel);
    }
}
