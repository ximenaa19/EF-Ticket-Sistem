using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed class CreateAirportValidator : AbstractValidator<CreateAirportCommand>
{
    public CreateAirportValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(command => command.IataCode)
            .NotEmpty()
            .MaximumLength(3);

        RuleFor(command => command.IcaoCode)
            .NotEmpty()
            .MaximumLength(4);

        RuleFor(command => command.CityId)
            .NotEmpty();
    }
}
