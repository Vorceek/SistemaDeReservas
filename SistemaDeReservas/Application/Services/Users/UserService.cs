

using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {

        public async Task<IEnumerable<UserResponseDto>> GetAllUser()
        {
            var users = await repository.GetAllAsync();
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Cpf = u.Cpf
            });
        }

        public async Task<int> InsertAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf
            };
            return await repository.InsertAsync(user);
        }
    }
}