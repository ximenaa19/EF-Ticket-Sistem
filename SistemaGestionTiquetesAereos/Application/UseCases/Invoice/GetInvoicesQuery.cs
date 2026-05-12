using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Invoice;

public sealed record GetInvoicesQuery : IRequest<IReadOnlyList<Domain.Entities.Invoice>>;
