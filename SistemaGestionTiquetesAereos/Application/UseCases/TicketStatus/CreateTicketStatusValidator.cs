using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class CreateTicketStatusValidator : AbstractValidator<CreateTicketStatusCommand>
{
    public CreateTicketStatusValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
