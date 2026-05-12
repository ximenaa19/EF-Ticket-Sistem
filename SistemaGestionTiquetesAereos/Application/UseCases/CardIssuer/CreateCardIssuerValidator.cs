using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class CreateCardIssuerValidator : AbstractValidator<CreateCardIssuerCommand>
{
    public CreateCardIssuerValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
