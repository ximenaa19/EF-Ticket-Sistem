using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PaymentMethodType;

public sealed class UpdatePaymentMethodTypeValidator : AbstractValidator<UpdatePaymentMethodTypeCommand>
{
    public UpdatePaymentMethodTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
