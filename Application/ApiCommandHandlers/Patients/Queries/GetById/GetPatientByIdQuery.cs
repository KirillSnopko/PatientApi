using Domain.DataTransferObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Application.ApiCommandHandlers.Patients.Queries.GetById;

public sealed record GetPatientByIdQuery([Required] string PublicId) : IRequest<PatientDto>
{
}
