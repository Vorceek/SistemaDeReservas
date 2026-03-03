namespace SistemaDeReservas.Application.DTOs.Quartos
{
    public class ResponseQuartoDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Capacidade { get; set; }
        public decimal Diaria { get; set; }
        public Guid HotelId { get; set; }
    }
}
