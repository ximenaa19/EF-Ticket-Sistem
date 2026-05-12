using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.IsoCode)
            .NotEmpty()
            .MaximumLength(3);

        RuleFor(command => command.ContinentId)
            .NotEmpty();
    }
}
