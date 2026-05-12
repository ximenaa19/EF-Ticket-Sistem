using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceValidator()
    {
        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.InvoiceNumber)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(command => command.TotalAmount)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.Currency)
            .NotEmpty()
            .MaximumLength(3);
    }
}
