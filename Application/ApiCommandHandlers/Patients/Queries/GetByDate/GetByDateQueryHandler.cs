using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using Shared.Extensions;


namespace Application.ApiCommandHandlers.Patients.Queries.GetData;

public sealed class GetByDateQueryHandler : IRequestHandler<GetByDateQuery, List<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public GetByDateQueryHandler(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<List<PatientDto>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
    {
        var queryable = _patientRepository.Queryable();

        if (request.DateStart.HasValue)
        {
            var date = DateTime.SpecifyKind(request.DateStart.Value, DateTimeKind.Utc);
            queryable = queryable.Where(x => x.DateOfBirth.Date >= date.Date);
        }

        if (request.DateEnd.HasValue)
        {
            var date = DateTime.SpecifyKind(request.DateEnd.Value, DateTimeKind.Utc);
            queryable = queryable.Where(x => x.DateOfBirth.Date <= date.Date);
        }

        if (request.InDates != null && request.InDates.Any())
        {
            var dates = new List<DateTime>();
            foreach (var item in request.InDates)
            {
                var date = item.ToDate();
                if (date != null)
                {
                    dates.Add(date.Value);
                }
            }

            if (dates.Count > 0)
            {
                queryable = queryable.Where(x => dates.Any(z => z.Date.Date == x.DateOfBirth.Date));
            }
            else
            {
                return new List<PatientDto>(0);
            }
        }

        return await queryable.ProjectTo<PatientDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
