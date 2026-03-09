using SistemaDeReservas.Application.DTOs.Quartos;
using SistemaDeReservas.Application.Interfaces.Quartos;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Services.Quartos
{
    public class QuartoService(IQuartoRepository repository) : IQuartoService
    {
        public async Task<IEnumerable<ResponseQuartoDto>> GetAllQuarto()
        {
            var quarto = await repository.GetAllAsync();
            return quarto.Select(q => new ResponseQuartoDto
            {
                Id = q.Id,
                Nome = q.Nome,
                Capacidade = q.Capacidade,
                Quantidade = q.Quantidade,
                Diaria = q.Diaria,
                HotelId = q.HotelId
            });
        }

        public async Task<ResponseQuartoDto> InsertAsync(CreateQuartoDto dto)
        {
            var quarto = new Quarto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Capacidade = dto.Capacidade,
                Quantidade = dto.Quantidade,
                Diaria = dto.Diaria,
                HotelId = dto.HotelId
            };
            await repository.InsertAsync(quarto);
            return new ResponseQuartoDto
            {
                Id = quarto.Id,
                Nome = quarto.Nome,
                Capacidade = quarto.Capacidade,
                Quantidade = quarto.Quantidade,
                Diaria = quarto.Diaria,
                HotelId = quarto.HotelId
            };
        }
    }
}
