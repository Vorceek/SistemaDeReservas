namespace SistemaDeReservas.Application.DTOs.Users
{
    public class ResponseUserDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
    }
}
