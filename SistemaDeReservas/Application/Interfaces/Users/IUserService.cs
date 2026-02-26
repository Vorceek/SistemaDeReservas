using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUser();
        Task<int> InsertAsync(CreateUserDto dto);
    }
}

