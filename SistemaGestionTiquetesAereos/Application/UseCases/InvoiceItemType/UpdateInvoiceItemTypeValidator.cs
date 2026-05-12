using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed class UpdateInvoiceItemTypeValidator : AbstractValidator<UpdateInvoiceItemTypeCommand>
{
    public UpdateInvoiceItemTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
