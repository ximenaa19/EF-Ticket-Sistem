using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed record CreateTicketStatusCommand(string Name) : IRequest<Guid>;
