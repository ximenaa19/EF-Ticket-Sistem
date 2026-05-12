using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed record UpdateInvoiceItemCommand(Guid Id, Guid InvoiceId,
    Guid InvoiceItemTypeId,
    string Description,
    decimal Amount,
    string Currency, bool IsActive) : IRequest;
