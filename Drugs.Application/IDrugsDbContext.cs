using Drugs.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application
{
    public interface IDrugsDbContext
    {
        DbSet<Drug> Drugs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
