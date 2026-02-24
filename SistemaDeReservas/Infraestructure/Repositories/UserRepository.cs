using Dapper;
using SistemaDeReservas.Domain.Interfaces;
using SistemaDeReservas.Infraestructure.Entities;
using System.Data;

namespace SistemaDeReservas.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM Users";
            return await _connection.QueryAsync<User>(sql);
        }
    }
}
