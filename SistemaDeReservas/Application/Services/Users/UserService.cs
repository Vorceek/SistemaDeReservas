

using SistemaDeReservas.Application.DTOs.Users;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {

        public async Task<IEnumerable<ResponseUserDto>> GetAllUser()
        {
            var users = await repository.GetAllAsync();
            return users.Select(u => new ResponseUserDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Cpf = u.Cpf
            });
        }

        public async Task<ResponseUserDto> InsertAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cpf = dto.Cpf
            };
            await repository.InsertAsync(user);
            return new ResponseUserDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Cpf = user.Cpf
            };
        }
    }
}