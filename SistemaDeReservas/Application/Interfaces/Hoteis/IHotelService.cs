using SistemaDeReservas.Application.DTOs.Hoteis;

namespace SistemaDeReservas.Application.Interfaces.Hoteis
{
    public interface IHotelService
    {
        Task<IEnumerable<ResponseHotelDto>> GetAllHotel();
        Task<int> InsertAsync(CreateHotelDto dto);
    }
}
