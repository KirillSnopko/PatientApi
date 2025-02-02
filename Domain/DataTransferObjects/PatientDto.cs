using Domain.Enums;

namespace Domain.DataTransferObjects;

public class PatientDto
{
    public NameDto Name { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool Active { get; set; }
}
