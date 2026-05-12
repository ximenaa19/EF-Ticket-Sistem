using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed class UpdatePaymentValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

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
