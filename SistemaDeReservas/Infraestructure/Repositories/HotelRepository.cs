using Dapper;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Domain.Entities;
using System.Data;

namespace SistemaDeReservas.Infraestructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IDbConnection _connection;

        public HotelRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            var sql = "SELECT Id, Nome, Cnpj FROM Hoteis";
            return await _connection.QueryAsync<Hotel>(sql);
        }

        public async Task<int> InsertAsync(Hotel hotel)
        {
            var sql = @"
                INSERT INTO Hoteis (Id, Nome, Cnpj)
                VALUES (@Id, @Nome, @Cnpj)";

            return await _connection.ExecuteAsync(sql, hotel);
        }
    }
}
