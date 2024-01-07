using Drugs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommand : IRequest<Guid>
    {
        public DrugVersion DrugVersion { get; set; }
    }
}
