using MediatR;

namespace AirlineTicketSystem.Application.UseCases.InvoiceItemType;

public sealed record GetInvoiceItemTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.InvoiceItemType>;
