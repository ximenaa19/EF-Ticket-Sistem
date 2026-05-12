using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed record GetInvoiceByIdQuery(Guid Id) : IRequest<Domain.Entities.Invoice>;
