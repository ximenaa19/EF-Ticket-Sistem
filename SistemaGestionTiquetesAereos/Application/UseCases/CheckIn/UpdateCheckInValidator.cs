using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class UpdateCheckInValidator : AbstractValidator<UpdateCheckInCommand>
{
    public UpdateCheckInValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.TicketId)
            .NotEmpty();

        RuleFor(command => command.CheckInStatusId)
            .NotEmpty();
    }
}
