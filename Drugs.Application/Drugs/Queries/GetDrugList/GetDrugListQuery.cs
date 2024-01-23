using MediatR;

namespace Drugs.Application.Drugs.Queries.GetDrugList
{
    public class GetDrugListQuery : IRequest<DrugListVm>
    {
        public string? Name {  get; set; }
        public List<string>? Groups { get; set; }
    }
}