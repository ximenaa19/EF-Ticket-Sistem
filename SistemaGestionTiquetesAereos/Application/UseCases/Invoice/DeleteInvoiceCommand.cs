using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed record DeleteInvoiceCommand(Guid Id) : IRequest;
