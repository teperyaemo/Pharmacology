using Drugs.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.Interfaces
{
    public interface IDrugsDbContext
    {
        DbSet<Drug> Drugs { get; set; }
        DbSet<DrugVersion> Versions { get; set; }
        DbSet<PharmaGroup> Groups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
