using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class UpdateRouteHandler : IRequestHandler<UpdateRouteCommand>
{
    private readonly IRoute _routeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRouteHandler(IRoute routeRepository, IUnitOfWork unitOfWork)
    {
        _routeRepository = routeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _routeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Route), request.Id);

        entity.Update(request.OriginAirportId, request.DestinationAirportId, request.DistanceKm, request.IsActive);

        _routeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
