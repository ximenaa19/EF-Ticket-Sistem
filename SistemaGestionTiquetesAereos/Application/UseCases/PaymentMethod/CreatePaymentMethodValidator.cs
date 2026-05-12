using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethod;

public sealed class CreatePaymentMethodValidator : AbstractValidator<CreatePaymentMethodCommand>
{
    public CreatePaymentMethodValidator()
    {
        RuleFor(command => command.ClientId)
            .NotEmpty();

        RuleFor(command => command.PaymentMethodTypeId)
            .NotEmpty();

        RuleFor(command => command.MaskedNumber)
            .MaximumLength(30);
    }
}
