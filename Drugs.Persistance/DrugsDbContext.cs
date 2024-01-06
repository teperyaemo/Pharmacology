using Drugs.Application;
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

        public DrugsDbContext(DbContextOptions<DrugsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DrugConfigurations());
            base.OnModelCreating(builder);
        }
    }
}
