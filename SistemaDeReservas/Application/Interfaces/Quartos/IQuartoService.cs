using SistemaDeReservas.Application.DTOs.Quartos;

namespace SistemaDeReservas.Application.Interfaces.Quartos
{
    public interface IQuartoService
    {
        Task<IEnumerable<ResponseQuartoDto>> GetAllQuarto();
        Task<int> InsertAsync(CreateQuartoDto dto);
    }
}
