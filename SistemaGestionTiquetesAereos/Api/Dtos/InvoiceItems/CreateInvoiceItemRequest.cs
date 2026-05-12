namespace AirlineTicketSystem.Api.Dtos.InvoiceItems;

public sealed record CreateInvoiceItemRequest(
    Guid InvoiceId,
    Guid InvoiceItemTypeId,
    string Description,
    decimal Amount,
    string Currency);
