using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Schemas;

namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class NameConfiguration : BaseEntityConfiguration<Name, string>
{
    public override void Configure(EntityTypeBuilder<Name> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Use).HasColumnName(NameSchema.Columns.Use);

        builder.Property(x => x.Family).HasColumnName(NameSchema.Columns.Family);

        builder.Property(x => x.Given).HasColumnName(NameSchema.Columns.Given);

        builder.HasIndex(x => x.Id).HasFilter($"{ColumnsBase.IsDeleted} = false").IsUnique();

        builder.ToTable(NameSchema.Table);
    }
}
