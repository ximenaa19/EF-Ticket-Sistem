using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed record GetInvoiceItemsQuery : IRequest<IReadOnlyList<Domain.Entities.InvoiceItem>>;
