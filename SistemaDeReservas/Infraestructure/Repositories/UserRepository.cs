using Dapper;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Domain.Entities;
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
            var sql = "SELECT Id, Nome, Cpf FROM Users";
            return await _connection.QueryAsync<User>(sql);
        }

        public async Task<int> InsertAsync(User user)
        {
            var sql = @"
                INSERT INTO Users (Nome, Cpf)
                VALUES (@Nome, @Cpf)";

            return await _connection.ExecuteAsync(sql, user);
        }
    }
}
