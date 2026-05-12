using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class DeleteFlightSeatHandler : IRequestHandler<DeleteFlightSeatCommand>
{
    private readonly IFlightSeat _flightSeatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightSeatHandler(IFlightSeat flightSeatRepository, IUnitOfWork unitOfWork)
    {
        _flightSeatRepository = flightSeatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFlightSeatCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightSeatRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightSeat), request.Id);

        _flightSeatRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
