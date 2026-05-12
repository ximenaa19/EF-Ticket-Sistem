using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class DeleteRouteHandler : IRequestHandler<DeleteRouteCommand>
{
    private readonly IRoute _routeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRouteHandler(IRoute routeRepository, IUnitOfWork unitOfWork)
    {
        _routeRepository = routeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _routeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Route), request.Id);

        _routeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
