using FluentValidation;
using SistemaDeReservas.Application.DTOs.Reservas;

namespace SistemaDeReservas.Application.Validators.Reservas
{
    public class CreateReservaValidator : AbstractValidator<CreateReservaDto>
    {
        public CreateReservaValidator()
        {
            RuleFor(x => x.HotelId)
                .NotEmpty().WithMessage("HotelId é obrigatório");

            RuleFor(x => x.QuartoId)
                .NotEmpty().WithMessage("QuartoId é obrigatório");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId é obrigatório");

            RuleFor(x => x.CheckIn)
                .LessThan(x => x.CheckOut)
                .WithMessage("CheckIn deve ser menor que CheckOut");
        }
    }
}