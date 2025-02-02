using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Patients.Queries.GetAll;

[UsedImplicitly]
public sealed class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetPatientsQueryHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        var queryable = _repository.Queryable();

        if (request.SortByFamilyNameAsc)
        {
            queryable = queryable.OrderBy(x => x.Name.Family);
        }
        else
        {
            queryable = queryable.OrderByDescending(x => x.Name.Family);
        }

        return queryable.Skip(request.PaginationParams.Offset)
                        .Take(request.PaginationParams.Limit)
                        .ProjectTo<PatientDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
    }
}
