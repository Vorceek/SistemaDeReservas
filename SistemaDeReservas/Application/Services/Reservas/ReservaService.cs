using SistemaDeReservas.Application.DTOs.Reservas;
using SistemaDeReservas.Application.Interfaces.Hoteis;
using SistemaDeReservas.Application.Interfaces.Quartos;
using SistemaDeReservas.Application.Interfaces.Reservas;
using SistemaDeReservas.Application.Interfaces.Users;
using SistemaDeReservas.Domain.Entities;
using System.Runtime.CompilerServices;

namespace SistemaDeReservas.Application.Services.Reservas
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IQuartoRepository _quartoRepository;
        private readonly IUserRepository _userRepository;

        public ReservaService(IHotelRepository hotelRepository, IReservaRepository reservaRepository, IQuartoRepository quartoRepository, IUserRepository userRepository)
        {
            _hotelRepository = hotelRepository;
            _reservaRepository = reservaRepository;
            _quartoRepository = quartoRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ResponseReservaDto>> GetAllReserva()
        {
            var reserva = await _reservaRepository.GetAllAsync();
            return reserva.Select(r => new ResponseReservaDto
            {
                Id = r.Id,
                HotelId = r.HotelId,
                QuartoId = r.QuartoId,
                UserId = r.UserId,
                CheckIn = r.CheckIn,
                CheckOut = r.CheckOut
            });
        }

        public async Task<ResponseReservaDto> InsertAsync(CreateReservaDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            if (hotel == null)
                throw new Exception("Hotel não encontrado");

            var quarto = await _quartoRepository.GetByIdAsync(dto.QuartoId);
            if (quarto == null)
                throw new Exception("Quarto não encontrado");
            if (quarto.HotelId != dto.HotelId)
                throw new Exception("Quarto não pertence a esse hotel");

            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new Exception("User não encontrado");

            if (dto.CheckIn >= dto.CheckOut)
                throw new Exception("CheckIn deve ser anterior ao CheckOut");
            if (dto.CheckIn < DateTime.Today)
                throw new Exception("CheckIn não pode ser no passado");

            var reserva = new Reserva
            {
                Id = Guid.NewGuid(),
                HotelId = dto.HotelId,
                QuartoId = dto.QuartoId,
                UserId = dto.UserId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut
            };
            
            await _reservaRepository.InsertAsync(reserva);
            return new ResponseReservaDto
            {
                Id = reserva.Id,
                HotelId = reserva.HotelId,
                QuartoId = reserva.QuartoId,
                UserId = reserva.UserId,
                CheckIn = reserva.CheckIn,
                CheckOut = reserva.CheckOut
            };
        }
    }
}
