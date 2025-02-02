using Domain.DataTransferObjects;
using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.ApiCommandHandlers.Patients.Handlers.Update;

public sealed record UpdatePatientCommand : IRequest
{
    public Gender Gender { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public bool Active { get; set; }

    [Required]
    public NameDto Name { get; set; }
}
