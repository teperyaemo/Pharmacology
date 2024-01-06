using Microsoft.EntityFrameworkCore;
using Drugs.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drugs.Persistance.EntityTypeConfigurations
{
    internal class DrugConfigurations : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.HasKey(drug => drug.DrugId);
            builder.HasIndex(drug => drug.DrugId).IsUnique();
        }
    }
}
