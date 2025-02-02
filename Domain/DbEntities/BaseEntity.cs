using Domain.Interfaces;

namespace Domain.DbEntities;

public abstract class BaseEntity<TId> : ISoftDeletable
{
    public TId Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}
