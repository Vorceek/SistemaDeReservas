namespace SistemaDeReservas.Application.DTOs.Reservas
{
    public class UpdateReservaDto
    {
        public Guid HotelId { get; set; }
        public Guid QuartoId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
