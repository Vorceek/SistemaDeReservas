using FluentValidation;
using SistemaDeReservas.Application.DTOs.Hoteis;

namespace SistemaDeReservas.Application.Validators.Hoteis
{
    public class CreateHotelValidator : AbstractValidator<CreateHotelDto>
    {
        public CreateHotelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(2, 100).WithMessage("Nome deve ter entre 2 e 100 caracteres");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("Cnpj é obrigatório")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres");
        }
    }
}