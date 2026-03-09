using FluentValidation;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using SistemaDeReservas.Application.DTOs.Quartos;

namespace SistemaDeReservas.Application.Validators.Quartos
{
    public class CreateQuartoValidator : AbstractValidator<CreateQuartoDto>
    {
        public CreateQuartoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(2, 100).WithMessage("Nome deve ter entre 2 e 100 caracteres");

            RuleFor(x => x.Quantidade)
                .NotEmpty().WithMessage("Quantidade é obrigatório")
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que 0");

            RuleFor(x => x.Capacidade)
                .NotEmpty().WithMessage("Capacidade é obrigatório")
                .GreaterThan(0).WithMessage("Capacidade deve ser maior que 0");

            RuleFor(x => x.Diaria)
                .NotEmpty().WithMessage("Diária é obrigatório")
                .GreaterThan(0).WithMessage("Diária deve ser maior que 0");

            RuleFor(x => x.HotelId)
                .NotEmpty().WithMessage("HotelId é obrigatório");
        }
    }
}