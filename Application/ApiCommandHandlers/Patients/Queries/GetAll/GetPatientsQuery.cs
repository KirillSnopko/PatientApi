using Domain.DataTransferObjects;
using MediatR;
using Shared.Models;

namespace Application.ApiCommandHandlers.Patients.Queries.GetAll;

public sealed record GetPatientsQuery : IRequest<List<PatientDto>>
{
    public PaginationParams PaginationParams { get; set; }

    public bool SortByFamilyNameAsc { get; set; }
}
