using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed class UpdateRegionValidator : AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.CountryId)
            .NotEmpty();
    }
}
