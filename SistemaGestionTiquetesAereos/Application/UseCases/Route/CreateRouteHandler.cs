using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class CreateRouteHandler : IRequestHandler<CreateRouteCommand, Guid>
{
    private readonly IRoute _routeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRouteHandler(IRoute routeRepository, IUnitOfWork unitOfWork)
    {
        _routeRepository = routeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Route(request.OriginAirportId, request.DestinationAirportId, request.DistanceKm);

        await _routeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
