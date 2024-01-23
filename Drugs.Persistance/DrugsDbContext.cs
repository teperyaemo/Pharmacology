using Drugs.Application.Interfaces;
using Drugs.Domain;
using Drugs.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Drugs.Persistance
{
    public class DrugsDbContext : DbContext, IDrugsDbContext
    {
        public DbSet<Drug> Drugs {  get; set; }
        public DbSet<DrugVersion> Versions { get; set; }

        public DrugsDbContext(DbContextOptions<DrugsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DrugConfigurations());
            builder.ApplyConfiguration(new DrugVersionConfigurations());
            base.OnModelCreating(builder);
        }
    }
}
