using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed class CreateInvoiceItemValidator : AbstractValidator<CreateInvoiceItemCommand>
{
    public CreateInvoiceItemValidator()
    {
        RuleFor(command => command.InvoiceId)
            .NotEmpty();

        RuleFor(command => command.InvoiceItemTypeId)
            .NotEmpty();

        RuleFor(command => command.Description)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(command => command.Amount)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.Currency)
            .NotEmpty()
            .MaximumLength(3);
    }
}
