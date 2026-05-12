using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.PersonId)
            .NotEmpty();
    }
}
