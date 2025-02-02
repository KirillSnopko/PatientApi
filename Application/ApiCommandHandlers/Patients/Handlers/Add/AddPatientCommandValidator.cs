using FluentValidation;

namespace Application.ApiCommandHandlers.Patients.Handlers.Add;

public sealed class AddPatientCommandValidator : AbstractValidator<AddPatientCommand>
{
    public AddPatientCommandValidator()
    {
        RuleFor(x => x.DateOfBirth).NotEmpty();
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name.Family).NotEmpty();
    }
}
