namespace SistemaDeReservas.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
    }
}
