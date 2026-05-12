using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed record DeleteInvoiceItemCommand(Guid Id) : IRequest;
