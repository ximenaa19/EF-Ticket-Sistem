using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed record UpdateTicketStatusCommand(Guid Id, string Name, bool IsActive) : IRequest;
