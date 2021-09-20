using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validator
{
    public class CarUseValidator : AbstractValidator<CarUse>
    {
        public CarUseValidator()
        {
            RuleFor(c => c.ReasonForUse)
                .NotEmpty().WithMessage("Por Favor digite um Motivo.")
                .NotNull().WithMessage("Por Favor digite um Motivo.")
                .MaximumLength(200).WithMessage("Máximo Caracteres 200");
        }
    }
}
