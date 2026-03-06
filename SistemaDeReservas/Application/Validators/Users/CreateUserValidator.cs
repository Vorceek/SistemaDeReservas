using FluentValidation;
using SistemaDeReservas.Application.DTOs.Users;

namespace SistemaDeReservas.Application.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(2, 100).WithMessage("Nome deve ter entre 2 e 100 caracteres");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("Cpf é obrigátório")
                .Length(11).WithMessage("Cpf deve ter 11 caracteres");
        }
    }
}
