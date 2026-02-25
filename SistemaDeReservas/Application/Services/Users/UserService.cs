using SistemaDeReservas.Application.Interfaces;
using SistemaDeReservas.Domain.Interfaces;
using SistemaDeReservas.Infraestructure.Entities;

namespace SistemaDeReservas.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> InsertAsync(User user)
        {
            if (user == null) return 0;
            return await _repository.InsertAsync(user);
        }
    }
}