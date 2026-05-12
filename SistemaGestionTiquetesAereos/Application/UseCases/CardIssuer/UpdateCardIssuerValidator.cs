using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class UpdateCardIssuerValidator : AbstractValidator<UpdateCardIssuerCommand>
{
    public UpdateCardIssuerValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
