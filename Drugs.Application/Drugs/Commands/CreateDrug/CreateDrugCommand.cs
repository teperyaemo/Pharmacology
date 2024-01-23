using Drugs.Domain;
using MediatR;

namespace Drugs.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommand : IRequest<Guid>
    {
        public DrugVersion DrugVersion { get; set; }
    }
}
