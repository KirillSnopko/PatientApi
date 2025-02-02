using FluentValidation;
using Shared.Models;

namespace Application.ApiCommandHandlers.Validation;

public sealed class PaginationValidator : AbstractValidator<PaginationParams>
{
    public PaginationValidator()
    {
        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Limit)
            .InclusiveBetween(1, 100);
    }
}
