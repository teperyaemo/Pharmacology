using Drugs.Application.Interfaces;
using Drugs.Domain;
using Drugs.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Persistance
{
    public class DrugsDbContext : DbContext, IDrugsDbContext
    {
        public DbSet<Drug> Drugs {  get; set; }
        public DbSet<DrugVersion> Versions { get; set; }
        public DbSet<PharmaGroup> Groups { get; set; }

        public DrugsDbContext(DbContextOptions<DrugsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DrugConfigurations());
            builder.ApplyConfiguration(new DrugVersionConfigurations());
            builder.ApplyConfiguration(new PharmaGroupConfigurations());
            base.OnModelCreating(builder);
        }
    }
}
