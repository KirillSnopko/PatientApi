using Application.ApiCommandHandlers.Validation;
using FluentValidation;

namespace Application.ApiCommandHandlers.Patients.Queries.GetAll;

public sealed class GetPatientsQueryValidator : AbstractValidator<GetPatientsQuery>
{
    public GetPatientsQueryValidator()
    {
        RuleFor(x => x.PaginationParams)
            .NotNull().SetValidator(new PaginationValidator());
    }
}
