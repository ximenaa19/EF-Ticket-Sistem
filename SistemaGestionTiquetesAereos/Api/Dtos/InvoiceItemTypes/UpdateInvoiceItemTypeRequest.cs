namespace AirlineTicketSystem.Api.Dtos.InvoiceItemTypes;

public sealed record UpdateInvoiceItemTypeRequest(
    string Name,
    bool IsActive);
