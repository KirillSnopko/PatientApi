using Domain.DbEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Schemas;


namespace Persistence.EntityConfigurations;

[UsedImplicitly]
internal class PatientConfiguration : BaseEntityConfiguration<Patient, long>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Gender).HasColumnName(PatientSchema.Columns.Gender);

        builder.Property(x => x.DateOfBirth).HasColumnName(PatientSchema.Columns.DateOfBirth);

        builder.Property(x => x.Active).HasColumnName(PatientSchema.Columns.Active);

        builder.Property(x => x.NameId).HasColumnName(PatientSchema.Columns.NameId);

        builder.HasIndex(x => x.Id).HasFilter($"{ColumnsBase.IsDeleted} = false").IsUnique();

        builder.ToTable(PatientSchema.Table);
    }
}
