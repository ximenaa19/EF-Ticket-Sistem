using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class UpdateFlightStatusTransitionHandler : IRequestHandler<UpdateFlightStatusTransitionCommand>
{
    private readonly IFlightStatusTransition _flightStatusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlightStatusTransitionHandler(IFlightStatusTransition flightStatusTransitionRepository, IUnitOfWork unitOfWork)
    {
        _flightStatusTransitionRepository = flightStatusTransitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFlightStatusTransitionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightStatusTransitionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightStatusTransition), request.Id);

        entity.Update(request.FlightId, request.FromFlightStatusId, request.ToFlightStatusId, request.ChangedAt, request.IsActive);

        _flightStatusTransitionRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
