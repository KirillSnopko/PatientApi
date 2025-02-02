using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;


namespace Application.ApiCommandHandlers.Patients.Handlers.Delete;

[UsedImplicitly]
public sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _repository;

    public DeletePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.Queryable().FirstOrDefaultAsync(x=>x.NameId==request.PublicId);

        if (patient is null)
        {
            throw new ArgumentNullException("Patient not found");
        }

        patient.SoftDelete();
        await _repository.UpdateAsync(patient);
    }
}
