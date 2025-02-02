using Domain.DbEntities;
using JetBrains.Annotations;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.ApiCommandHandlers.Patients.Handlers.Add;

[UsedImplicitly]
public sealed class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, AddPatientResponse>
{
    private readonly IPatientRepository _patientRepository;

    public AddPatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<AddPatientResponse> Handle(AddPatientCommand request, CancellationToken cancellationToken)
    {
        var name = new Name
        {
            Use = request.Name.Use,
            Family = request.Name.Family,
            Given = request.Name.Given
        };

        var patient = new Patient
        {
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth,
            Active = request.Active,
            Name = name,
            NameId = name.Id
        };

        await _patientRepository.CreateAsync(patient);

        return new AddPatientResponse { PublicId = name.Id };
    }
}
