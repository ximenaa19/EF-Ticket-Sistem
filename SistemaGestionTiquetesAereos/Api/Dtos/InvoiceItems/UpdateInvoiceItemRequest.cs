namespace AirlineTicketSystem.Api.Dtos.InvoiceItems;

public sealed record UpdateInvoiceItemRequest(
    Guid InvoiceId,
    Guid InvoiceItemTypeId,
    string Description,
    decimal Amount,
    string Currency,
    bool IsActive);
