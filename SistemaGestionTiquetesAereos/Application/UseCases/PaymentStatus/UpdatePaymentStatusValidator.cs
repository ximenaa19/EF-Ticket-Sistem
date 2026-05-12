using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PaymentStatus;

public sealed class UpdatePaymentStatusValidator : AbstractValidator<UpdatePaymentStatusCommand>
{
    public UpdatePaymentStatusValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
