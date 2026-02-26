using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> InsertAsync(User user);
    }
}
