using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class GetRouteByIdHandler : IRequestHandler<GetRouteByIdQuery, Domain.Entities.Route>
{
    private readonly IRoute _routeRepository;

    public GetRouteByIdHandler(IRoute routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public async Task<Domain.Entities.Route> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
    {
        return await _routeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Route), request.Id);
    }
}
