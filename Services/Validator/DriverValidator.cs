using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validator
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por Favor digite um Nome.")
                .NotNull().WithMessage("Por Favor digite um Nome.")
                .MaximumLength(200).WithMessage("Máximo Caracteres 200");
        }
    }
}
