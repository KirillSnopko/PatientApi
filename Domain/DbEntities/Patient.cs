using Domain.Enums;

namespace Domain.DbEntities;

public class Patient : BaseEntity<long>
{
    public string NameId { get; set; }

    public virtual Name Name { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool Active { get; set; }
}

