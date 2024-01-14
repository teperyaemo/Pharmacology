using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.Drugs.Queries.GetDrug
{
    public class GetDrugQuery : IRequest<DrugVm>
    {
        public Guid DrugId { get; set; }
    }
}
