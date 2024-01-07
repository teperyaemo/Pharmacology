using Drugs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Drugs.Persistance.EntityTypeConfigurations
{
    public class PharmaGroupConfigurations : IEntityTypeConfiguration<PharmaGroup>
    {
        public void Configure(EntityTypeBuilder<PharmaGroup> builder)
        {
            builder.HasKey(group => group.GroupId);
            builder.HasIndex(group => group.GroupId).IsUnique();
        }
    }
}
