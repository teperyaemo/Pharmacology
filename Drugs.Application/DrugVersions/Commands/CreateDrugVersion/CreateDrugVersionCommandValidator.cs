using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.DrugVersions.Commands.CreateDrugVersion
{
    public class CreateDrugVersionCommandValidator : AbstractValidator<CreateDrugVersionCommand>
    {
        public CreateDrugVersionCommandValidator()
        {
            RuleFor(createCommand => createCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createCommand => createCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
