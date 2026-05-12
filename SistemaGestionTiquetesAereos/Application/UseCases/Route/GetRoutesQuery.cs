using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed record GetRoutesQuery : IRequest<IReadOnlyList<Domain.Entities.Route>>;
