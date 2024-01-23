using Drugs.Domain;
using Microsoft.EntityFrameworkCore;

namespace Drugs.Application.Interfaces
{
    public interface IDrugsDbContext
    {
        DbSet<Drug> Drugs { get; set; }
        DbSet<DrugVersion> Versions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}