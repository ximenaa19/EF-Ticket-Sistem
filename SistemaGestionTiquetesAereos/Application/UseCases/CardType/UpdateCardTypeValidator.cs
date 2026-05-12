using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class UpdateCardTypeValidator : AbstractValidator<UpdateCardTypeCommand>
{
    public UpdateCardTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
