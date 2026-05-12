using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed record DeleteInvoiceItemTypeCommand(Guid Id) : IRequest;
