using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed record CreateInvoiceCommand(Guid ReservationId,
    string InvoiceNumber,
    DateTime IssuedAt,
    decimal TotalAmount,
    string Currency) : IRequest<Guid>;
