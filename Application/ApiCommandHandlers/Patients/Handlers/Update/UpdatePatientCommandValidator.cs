using FluentValidation;

namespace Application.ApiCommandHandlers.Patients.Handlers.Update;

public sealed class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(x => x.DateOfBirth).NotEmpty();
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name.Family).NotEmpty();
        RuleFor(x => x.Name.Id).NotEmpty();
    }
}
