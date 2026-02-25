using SistemaDeReservas.Infraestructure.Entities;

namespace SistemaDeReservas.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<int> InsertAsync(User user);
    }
}
