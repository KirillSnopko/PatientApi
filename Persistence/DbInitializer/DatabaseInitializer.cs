using Domain.DbEntities;
using Newtonsoft.Json;
using Persistence.Repositories.Interfaces;
using System.Reflection;

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
            var fileName = "users.json";
            var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fileLocation = Path.Combine(assemblyLocation!, fileName);

            if (!File.Exists(fileLocation))
            {
                throw new FileNotFoundException($"File ({fileName}) not found");
            }

            var json = await File.ReadAllTextAsync(fileLocation);

            var users = JsonConvert.DeserializeObject<List<Patient>>(json);

            foreach (var item in users)
            {
                item.DateOfBirth = DateTime.SpecifyKind(item.DateOfBirth, DateTimeKind.Utc);
            }

            await _patientRepository.CreateAsync(users);
        }
    }
}