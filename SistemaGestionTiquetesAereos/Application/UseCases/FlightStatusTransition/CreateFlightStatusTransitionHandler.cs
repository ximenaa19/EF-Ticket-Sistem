using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class CreateFlightStatusTransitionHandler : IRequestHandler<CreateFlightStatusTransitionCommand, Guid>
{
    private readonly IFlightStatusTransition _flightStatusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightStatusTransitionHandler(IFlightStatusTransition flightStatusTransitionRepository, IUnitOfWork unitOfWork)
    {
        _flightStatusTransitionRepository = flightStatusTransitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightStatusTransitionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.FlightStatusTransition(request.FlightId, request.FromFlightStatusId, request.ToFlightStatusId, request.ChangedAt);

        await _flightStatusTransitionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
