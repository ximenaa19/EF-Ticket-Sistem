using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed record GetTicketStatusesQuery : IRequest<IReadOnlyList<Domain.Entities.TicketStatus>>;
