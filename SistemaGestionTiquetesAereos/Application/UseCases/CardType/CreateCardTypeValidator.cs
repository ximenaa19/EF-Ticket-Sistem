using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class CreateCardTypeValidator : AbstractValidator<CreateCardTypeCommand>
{
    public CreateCardTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
