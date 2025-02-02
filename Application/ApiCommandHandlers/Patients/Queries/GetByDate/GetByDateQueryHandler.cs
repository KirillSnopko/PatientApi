using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Patients.Queries.GetData;

public sealed class GetByDateQueryHandler : IRequestHandler<GetByDateQuery, List<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public Task<List<PatientDto>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
    {
        var queryable = _patientRepository.Queryable();

        if (request.DateStart.HasValue)
        {
            queryable = queryable.Where(x => x.DateOfBirth >= request.DateStart.Value);
        }

        if (request.DateEnd.HasValue)
        {
            queryable = queryable.Where(x => x.DateOfBirth <= request.DateEnd.Value);
        }

        return queryable.ProjectTo<PatientDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
