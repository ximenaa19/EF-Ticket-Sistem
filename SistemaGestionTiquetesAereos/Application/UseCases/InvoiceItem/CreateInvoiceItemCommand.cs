using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed record CreateInvoiceItemCommand(Guid InvoiceId,
    Guid InvoiceItemTypeId,
    string Description,
    decimal Amount,
    string Currency) : IRequest<Guid>;
