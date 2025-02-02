using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum Gender
{
    [Display(Name = "unknown")]
    Unknown = 1,

    [Display(Name = "Male")]
    Male = 2,

    [Display(Name = "Female")]
    Female = 3,

    [Display(Name = "Other")]
    Other = 4,
}
