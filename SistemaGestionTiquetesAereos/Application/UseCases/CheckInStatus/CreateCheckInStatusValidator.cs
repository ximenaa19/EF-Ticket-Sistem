using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class CreateCheckInStatusValidator : AbstractValidator<CreateCheckInStatusCommand>
{
    public CreateCheckInStatusValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
