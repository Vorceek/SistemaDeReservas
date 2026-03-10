using SistemaDeReservas.Application.DTOs.Quartos;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Application.Interfaces.Quartos;
using SistemaDeReservas.Application.Interfaces.Reservas;
using SistemaDeReservas.Domain.Entities;

namespace SistemaDeReservas.Application.Services.Quartos
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _quartoRepository;
        private readonly IHotelRepository _hotelRepository;

        public QuartoService(IQuartoRepository quartoRepository, IHotelRepository hotelRepository       )
        {
            _quartoRepository = quartoRepository;
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<ResponseQuartoDto>> GetAllQuarto()
        {
            var quarto = await _quartoRepository.GetAllAsync();
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
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            if (hotel == null)
                throw new Exception("Hotel não encontrado");

            var quarto = new Quarto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Capacidade = dto.Capacidade,
                Quantidade = dto.Quantidade,
                Diaria = dto.Diaria,
                HotelId = dto.HotelId
            };
            await _quartoRepository.InsertAsync(quarto);
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
