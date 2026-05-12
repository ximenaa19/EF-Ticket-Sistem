using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class CreateCheckInValidator : AbstractValidator<CreateCheckInCommand>
{
    public CreateCheckInValidator()
    {
        RuleFor(command => command.TicketId)
            .NotEmpty();

        RuleFor(command => command.CheckInStatusId)
            .NotEmpty();
    }
}
