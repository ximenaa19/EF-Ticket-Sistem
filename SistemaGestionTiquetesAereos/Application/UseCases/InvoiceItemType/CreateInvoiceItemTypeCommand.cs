using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed record CreateInvoiceItemTypeCommand(string Name) : IRequest<Guid>;
