using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed record DeleteTicketStatusCommand(Guid Id) : IRequest;
