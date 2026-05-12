using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class UpdateAirportAirlineValidator : AbstractValidator<UpdateAirportAirlineCommand>
{
    public UpdateAirportAirlineValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.AirportId)
            .NotEmpty();

        RuleFor(command => command.AirlineId)
            .NotEmpty();
    }
}
