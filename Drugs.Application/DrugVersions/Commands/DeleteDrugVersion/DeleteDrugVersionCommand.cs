using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.DrugVersions.Commands.DeleteDrugVersion
{
    public class DeleteDrugVersionCommand : IRequest<Unit>
    {
        public Guid VersionId { get; set; }
    }
}
