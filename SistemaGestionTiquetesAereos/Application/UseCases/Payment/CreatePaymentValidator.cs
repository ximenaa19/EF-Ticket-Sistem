using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class CreatePaymentValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentValidator()
    {
        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.PaymentMethodId)
            .NotEmpty();

        RuleFor(command => command.PaymentStatusId)
            .NotEmpty();

        RuleFor(command => command.Amount)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.Currency)
            .NotEmpty()
            .MaximumLength(3);
    }
}
