using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed record DeleteSessionCommand(Guid Id) : IRequest;
