using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class CreateSessionValidator : AbstractValidator<CreateSessionCommand>
{
    public CreateSessionValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty();

        RuleFor(command => command.Token)
            .NotEmpty()
            .MaximumLength(250);
    }
}
