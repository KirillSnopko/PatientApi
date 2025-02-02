using Domain.DbEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Persistence.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

internal class BaseEntityConfiguration<T, TKey> : IEntityTypeConfiguration<T> where T : BaseEntity<TKey>
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnName(ColumnsBase.Id);

        builder.Property(x => x.CreatedAt)
            .HasColumnName(ColumnsBase.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IsDeleted)
            .HasColumnName(ColumnsBase.IsDeleted)
            .HasDefaultValue(false)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DeletedAt)
            .HasColumnName(ColumnsBase.DeletedAt);

        builder.HasQueryFilter(u => !u.IsDeleted);

        builder.HasKey(x => x.Id);
    }
}