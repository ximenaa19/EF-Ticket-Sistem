using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed record UpdateInvoiceCommand(Guid Id, Guid ReservationId,
    string InvoiceNumber,
    DateTime IssuedAt,
    decimal TotalAmount,
    string Currency, bool IsActive) : IRequest;
