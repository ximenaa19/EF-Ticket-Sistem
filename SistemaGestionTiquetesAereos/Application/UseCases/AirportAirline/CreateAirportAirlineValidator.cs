using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class CreateAirportAirlineValidator : AbstractValidator<CreateAirportAirlineCommand>
{
    public CreateAirportAirlineValidator()
    {
        RuleFor(command => command.AirportId)
            .NotEmpty();

        RuleFor(command => command.AirlineId)
            .NotEmpty();
    }
}
