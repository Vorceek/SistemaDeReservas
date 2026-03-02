namespace SistemaDeReservas.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Cnpj { get; set; }
    }
}
