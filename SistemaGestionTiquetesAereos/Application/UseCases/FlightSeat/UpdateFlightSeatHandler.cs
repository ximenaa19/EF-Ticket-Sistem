using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class UpdateFlightSeatHandler : IRequestHandler<UpdateFlightSeatCommand>
{
    private readonly IFlightSeat _flightSeatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlightSeatHandler(IFlightSeat flightSeatRepository, IUnitOfWork unitOfWork)
    {
        _flightSeatRepository = flightSeatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFlightSeatCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightSeatRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightSeat), request.Id);

        entity.Update(request.FlightId, request.SeatNumber, request.CabinTypeId, request.SeatLocationTypeId, request.AvailabilityStatusId, request.IsActive);

        _flightSeatRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
