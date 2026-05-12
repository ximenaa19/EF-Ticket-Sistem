using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed record DeleteTicketCommand(Guid Id) : IRequest;
