using MediatR;

namespace Drugs.Application.Drugs.Commands.DeleteCommand
{
    public class DeleteDrugCommand : IRequest<Unit>
    {
        public Guid DrugId { get; set; }
    }
}
