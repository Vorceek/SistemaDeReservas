using SistemaDeReservas.Infraestructure.Entities;

namespace SistemaDeReservas.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
