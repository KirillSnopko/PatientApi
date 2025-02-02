using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;


namespace Application.ApiCommandHandlers.Patients.Handlers.Update;

[UsedImplicitly]
public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
{
    private readonly IPatientRepository _repository;

    public UpdatePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.Queryable().FirstOrDefaultAsync(x => x.NameId == request.Name.Id);

        if (patient is null)
        {
            throw new ArgumentNullException("Patient not found");
        }

        patient.DateOfBirth = request.DateOfBirth;
        patient.Active = request.Active;
        patient.Gender = request.Gender;

        var name = patient.Name;

        name.Use = request.Name.Use;
        name.Family = request.Name.Family;
        name.Given = request.Name.Given;

        await _repository.UpdateAsync(patient);
    }
}
