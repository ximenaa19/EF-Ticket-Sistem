using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class CreatePaymentMethodTypeValidator : AbstractValidator<CreatePaymentMethodTypeCommand>
{
    public CreatePaymentMethodTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
