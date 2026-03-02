namespace SistemaDeReservas.Application.DTOs.Hoteis
{
    public class ResponseHotelDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Cnpj { get; set; }
    }
}
