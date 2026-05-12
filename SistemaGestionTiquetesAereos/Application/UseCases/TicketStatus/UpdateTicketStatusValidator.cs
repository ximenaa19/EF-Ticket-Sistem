using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class UpdateTicketStatusValidator : AbstractValidator<UpdateTicketStatusCommand>
{
    public UpdateTicketStatusValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
