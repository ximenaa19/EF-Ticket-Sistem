using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

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
