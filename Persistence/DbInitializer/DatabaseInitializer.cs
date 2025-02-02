using Persistence.Repositories.Interfaces;

namespace Persistence.DbInitializer;

public sealed class DatabaseInitializer : IDatabaseInitializer
{
    private readonly IPatientRepository _patientRepository;

    public DatabaseInitializer(IPatientRepository petientRepository)
    {
        _patientRepository = petientRepository;
    }

    public async Task InitializeIfNeededAsync()
    {
        await InitPatients();
    }


    private async Task InitPatients()
    {
        if (!_patientRepository.Queryable().Any())
        {
            var data = new[] { 554, 265, 354, 469 };
            var sectors = data.Select(x => new Sector { Number = x }).ToList();
            await _sectorRepository.CreateAsync(sectors);
        }
    }
}
