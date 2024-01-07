using Drugs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drugs.Persistance.EntityTypeConfigurations
{
    public class DrugVersionConfigurations : IEntityTypeConfiguration<DrugVersion>
    {
        public void Configure(EntityTypeBuilder<DrugVersion> builder)
        {
            builder.HasKey(version => version.VersionId);
            builder.HasIndex(version => version.VersionId).IsUnique();
            builder.HasMany(version => version.Groups)
                .WithMany(groups => groups.Versions);
        }
    }
}
