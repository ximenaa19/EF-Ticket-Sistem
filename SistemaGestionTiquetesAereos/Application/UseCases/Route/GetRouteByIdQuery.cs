using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed record GetRouteByIdQuery(Guid Id) : IRequest<Domain.Entities.Route>;
