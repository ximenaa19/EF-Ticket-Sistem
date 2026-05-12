using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class DeleteRouteStopHandler : IRequestHandler<DeleteRouteStopCommand>
{
    private readonly IRouteStop _routeStopRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRouteStopHandler(IRouteStop routeStopRepository, IUnitOfWork unitOfWork)
    {
        _routeStopRepository = routeStopRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRouteStopCommand request, CancellationToken cancellationToken)
    {
        var entity = await _routeStopRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RouteStop), request.Id);

        _routeStopRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
