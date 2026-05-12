using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed record DeleteRouteCommand(Guid Id) : IRequest;
