using Domain.DataTransferObjects;
using MediatR;

namespace Application.ApiCommandHandlers.Patients.Queries.GetData;

public sealed record GetByDateQuery : IRequest<List<PatientDto>>
{
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }

    public List<string> InDates { get; set; }
}
