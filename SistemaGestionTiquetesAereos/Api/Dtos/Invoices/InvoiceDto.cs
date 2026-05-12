namespace AirlineTicketSystem.Api.Dtos.Invoices;

public sealed record InvoiceDto(
    Guid Id,
    Guid ReservationId,
    string InvoiceNumber,
    DateTime IssuedAt,
    decimal TotalAmount,
    string Currency,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
