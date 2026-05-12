using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class GetRouteStopByIdHandler : IRequestHandler<GetRouteStopByIdQuery, Domain.Entities.RouteStop>
{
    private readonly IRouteStop _routeStopRepository;

    public GetRouteStopByIdHandler(IRouteStop routeStopRepository)
    {
        _routeStopRepository = routeStopRepository;
    }

    public async Task<Domain.Entities.RouteStop> Handle(GetRouteStopByIdQuery request, CancellationToken cancellationToken)
    {
        return await _routeStopRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RouteStop), request.Id);
    }
}
