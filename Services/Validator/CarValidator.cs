using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validator
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("Por Favor digite uma Marca.")
                .NotNull().WithMessage("Por Favor digite uma Marca.");

            RuleFor(c => c.Color)
               .NotEmpty().WithMessage("Por Favor digite uma Cor.")
               .NotNull().WithMessage("Por Favor digite uma Cor.");

            RuleFor(c => c.License)
               .NotEmpty().WithMessage("Por Favor digite uma Placa.")
               .NotNull().WithMessage("Por Favor digite uma Placa.")
               .MaximumLength(7).WithMessage("O Máximo de caracteres da Placa são 7");
        }
    }
}
