using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class CreateInvoiceItemTypeValidator : AbstractValidator<CreateInvoiceItemTypeCommand>
{
    public CreateInvoiceItemTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
