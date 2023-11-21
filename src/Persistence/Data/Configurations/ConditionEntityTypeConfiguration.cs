using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Conditions;

namespace Project.Persistence.Data.Configurations
{
    public class ConditionEntityTypeConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.LongDescription).IsRequired();
            builder.Property(c => c.ShortDescription).IsRequired();
        }
    }
}
