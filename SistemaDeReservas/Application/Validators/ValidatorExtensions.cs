using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SistemaDeReservas.Application.Validators
{
    public static class ValidatorExtensions
    {
        public static async Task<IActionResult?> ValidateAndBadRequestAsync<T>(
            this IValidator<T> validador, T dto)
        {
            var result = await validador.ValidateAsync(dto);
            if (!result.IsValid)
                return new BadRequestObjectResult(result.Errors.Select(e => e.ErrorMessage));

            return null;
        }
    }
}
