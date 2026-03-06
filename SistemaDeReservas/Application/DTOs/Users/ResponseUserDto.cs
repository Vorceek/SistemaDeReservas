namespace SistemaDeReservas.Application.DTOs.Users
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
    }
}
