using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class UpdateCheckInStatusValidator : AbstractValidator<UpdateCheckInStatusCommand>
{
    public UpdateCheckInStatusValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
