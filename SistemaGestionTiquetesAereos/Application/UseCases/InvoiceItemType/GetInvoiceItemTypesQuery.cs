using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed record GetInvoiceItemTypesQuery : IRequest<IReadOnlyList<Domain.Entities.InvoiceItemType>>;
