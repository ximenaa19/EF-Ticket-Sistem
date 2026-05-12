using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed class CreateRegionValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.CountryId)
            .NotEmpty();
    }
}
