using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class CreatePaymentStatusValidator : AbstractValidator<CreatePaymentStatusCommand>
{
    public CreatePaymentStatusValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
