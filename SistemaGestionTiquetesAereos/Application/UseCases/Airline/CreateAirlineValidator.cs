using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed class CreateAirlineValidator : AbstractValidator<CreateAirlineCommand>
{
    public CreateAirlineValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(command => command.IataCode)
            .NotEmpty()
            .Length(2, 3);
    }
}
