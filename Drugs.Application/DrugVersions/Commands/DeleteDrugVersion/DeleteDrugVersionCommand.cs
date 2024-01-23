using MediatR;

namespace Drugs.Application.DrugVersions.Commands.DeleteDrugVersion
{
    public class DeleteDrugVersionCommand : IRequest<Unit>
    {
        public Guid VersionId { get; set; }
    }
}