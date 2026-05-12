using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class DeleteFlightStatusTransitionHandler : IRequestHandler<DeleteFlightStatusTransitionCommand>
{
    private readonly IFlightStatusTransition _flightStatusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightStatusTransitionHandler(IFlightStatusTransition flightStatusTransitionRepository, IUnitOfWork unitOfWork)
    {
        _flightStatusTransitionRepository = flightStatusTransitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFlightStatusTransitionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightStatusTransitionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightStatusTransition), request.Id);

        _flightStatusTransitionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
