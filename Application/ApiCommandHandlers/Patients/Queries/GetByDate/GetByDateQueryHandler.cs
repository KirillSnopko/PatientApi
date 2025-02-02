using AutoMapper;
using Domain.DataTransferObjects;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Patients.Queries.GetData;

public sealed class GetByDateQueryHandler : IRequestHandler<GetByDateQuery, List<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public Task<List<PatientDto>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
