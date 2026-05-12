using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientValidator()
    {
        RuleFor(command => command.PersonId)
            .NotEmpty();
    }
}
