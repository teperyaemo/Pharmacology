using Drugs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.Drugs.Queries.GetDrugList
{
    public class GetDrugListQuery : IRequest<DrugListVm>
    {
        public string? Name {  get; set; }
        public List<string>? Groups { get; set; }
    }
}
