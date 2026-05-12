using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed record GetTicketsQuery : IRequest<IReadOnlyList<Domain.Entities.Ticket>>;
