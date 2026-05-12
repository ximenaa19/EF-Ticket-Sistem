namespace AirlineTicketSystem.Api.Dtos.Invoices;

public sealed record CreateInvoiceRequest(
    Guid ReservationId,
    string InvoiceNumber,
    DateTime IssuedAt,
    decimal TotalAmount,
    string Currency);
