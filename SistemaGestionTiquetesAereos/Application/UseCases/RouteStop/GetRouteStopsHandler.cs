using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class GetRouteStopsHandler : IRequestHandler<GetRouteStopsQuery, IReadOnlyList<Domain.Entities.RouteStop>>
{
    private readonly IRouteStop _routeStopRepository;

    public GetRouteStopsHandler(IRouteStop routeStopRepository)
    {
        _routeStopRepository = routeStopRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.RouteStop>> Handle(GetRouteStopsQuery request, CancellationToken cancellationToken)
    {
        return _routeStopRepository.GetAllAsync(cancellationToken);
    }
}
