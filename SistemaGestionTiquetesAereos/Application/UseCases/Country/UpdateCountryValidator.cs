using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

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
