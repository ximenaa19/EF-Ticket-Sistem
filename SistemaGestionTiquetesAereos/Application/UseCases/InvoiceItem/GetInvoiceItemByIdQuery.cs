using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItem;

public sealed record GetInvoiceItemByIdQuery(Guid Id) : IRequest<Domain.Entities.InvoiceItem>;
