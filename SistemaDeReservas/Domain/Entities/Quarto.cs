namespace SistemaDeReservas.Domain.Entities
{
    public class Quarto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Capacidade { get; set; }
        public decimal Diaria { get; set; }
        public Guid HotelId { get; set; }
    }
}
