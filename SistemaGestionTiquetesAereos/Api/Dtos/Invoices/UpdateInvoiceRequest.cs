namespace AirlineTicketSystem.Api.Dtos.Invoices;

public sealed record UpdateInvoiceRequest(
    Guid ReservationId,
    string InvoiceNumber,
    DateTime IssuedAt,
    decimal TotalAmount,
    string Currency,
    bool IsActive);
