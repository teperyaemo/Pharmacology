using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommandValidator : AbstractValidator<CreateDrugCommand>
    {
        public CreateDrugCommandValidator()
        {
            RuleFor(createCommand => createCommand.DrugVersion).NotNull().NotEmpty();
        }
    }
}
