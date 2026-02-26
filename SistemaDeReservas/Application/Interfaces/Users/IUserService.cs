using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<int> InsertAsync(User user);
    }
}
