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

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var sql = "SELECT Id, Nome, Cpf FROM Users WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = "SELECT Id, Nome, Cpf FROM Users";
            return await _connection.QueryAsync<User>(sql);
        }

        public async Task<int> InsertAsync(User user)
        {
            var sql = @"
                INSERT INTO Users (Id, Nome, Cpf)
                VALUES (@Id, @Nome, @Cpf)";

            return await _connection.ExecuteAsync(sql, user);
        }
    }
}
