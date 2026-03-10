using Dapper;
using SistemaDeReservas.Application.Interfaces.Reservas;
using SistemaDeReservas.Domain.Entities;
using System.Data;

namespace SistemaDeReservas.Infraestructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IDbConnection _connection;

        public ReservaRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Reserva?> GetByIdAsync(Guid id)
        {
            var sql = "SELECT Id, HotelId, QuartoId, UserId, CheckIn, CheckOut FROM Reservas WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Reserva>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            var sql = "SELECT Id, HotelId, QuartoId, UserId, CheckIn, CheckOut FROM Reservas";
            return await _connection.QueryAsync<Reserva>(sql);
        }

        public async Task<int> InsertAsync(Reserva reserva)
        {
            var sql = @"
                INSERT INTO Reservas (Id, HotelId, QuartoId, UserId, CheckIn, CheckOut)
                VALUES (@Id, @HotelId, @QuartoId, @UserId, @CheckIn, @CheckOut)";

            return await _connection.ExecuteAsync(sql, reserva);
        }
    }
}
