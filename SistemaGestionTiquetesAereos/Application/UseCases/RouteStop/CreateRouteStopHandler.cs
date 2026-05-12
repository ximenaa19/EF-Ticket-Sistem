using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class CreateRouteStopHandler : IRequestHandler<CreateRouteStopCommand, Guid>
{
    private readonly IRouteStop _routeStopRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRouteStopHandler(IRouteStop routeStopRepository, IUnitOfWork unitOfWork)
    {
        _routeStopRepository = routeStopRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRouteStopCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.RouteStop(request.RouteId, request.AirportId, request.StopOrder);

        await _routeStopRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
