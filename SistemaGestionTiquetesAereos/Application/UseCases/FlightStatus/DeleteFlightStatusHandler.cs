using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class DeleteFlightStatusHandler : IRequestHandler<DeleteFlightStatusCommand>
{
    private readonly IFlightStatus _flightStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightStatusHandler(IFlightStatus flightStatusRepository, IUnitOfWork unitOfWork)
    {
        _flightStatusRepository = flightStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFlightStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightStatus), request.Id);

        _flightStatusRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
