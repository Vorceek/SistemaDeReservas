using Dapper;
using SistemaDeReservas.Application.Interfaces.Quartos;
using SistemaDeReservas.Domain.Entities;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;

namespace SistemaDeReservas.Infraestructure.Repositories
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly IDbConnection _connection;

        public QuartoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Quarto>> GetAllAsync()
        {
            var sql = "SELECT Id, Nome, Quantidade, Capacidade, Diaria, HotelId FROM Quartos";
            return await _connection.QueryAsync<Quarto>(sql);
        }

        public async Task<int> InsertAsync(Quarto quarto)
        {
            var sql = @"
                INSERT INTO Quartos (Id, Nome, Quantidade, Capacidade, Diaria, HotelId)
                VALUES (@Id, @Nome, @Quantidade, @Capacidade, @Diaria, @HotelId)";

            return await _connection.ExecuteAsync(sql, quarto);
        }
    }
}