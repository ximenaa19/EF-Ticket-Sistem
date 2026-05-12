using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class GetRoutesHandler : IRequestHandler<GetRoutesQuery, IReadOnlyList<Domain.Entities.Route>>
{
    private readonly IRoute _routeRepository;

    public GetRoutesHandler(IRoute routeRepository)
    {
        _routeRepository = routeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Route>> Handle(GetRoutesQuery request, CancellationToken cancellationToken)
    {
        return _routeRepository.GetAllAsync(cancellationToken);
    }
}
