using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Patients.Queries.GetById;

[UsedImplicitly]
public sealed class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetPatientByIdQueryHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken) =>

        _repository.Queryable().Where(x => x.NameId == request.PublicId).ProjectTo<PatientDto>(_mapper.ConfigurationProvider)
                                      .FirstOrDefaultAsync(cancellationToken);

}
