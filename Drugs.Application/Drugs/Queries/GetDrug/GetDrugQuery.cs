using MediatR;

namespace Drugs.Application.Drugs.Queries.GetDrug
{
    public class GetDrugQuery : IRequest<DrugVm>
    {
        public Guid DrugId { get; set; }
    }
}
