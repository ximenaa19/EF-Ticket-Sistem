using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class UpdateRouteStopHandler : IRequestHandler<UpdateRouteStopCommand>
{
    private readonly IRouteStop _routeStopRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRouteStopHandler(IRouteStop routeStopRepository, IUnitOfWork unitOfWork)
    {
        _routeStopRepository = routeStopRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRouteStopCommand request, CancellationToken cancellationToken)
    {
        var entity = await _routeStopRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RouteStop), request.Id);

        entity.Update(request.RouteId, request.AirportId, request.StopOrder, request.IsActive);

        _routeStopRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
