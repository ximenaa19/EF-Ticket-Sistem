using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class CreateFlightSeatHandler : IRequestHandler<CreateFlightSeatCommand, Guid>
{
    private readonly IFlightSeat _flightSeatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightSeatHandler(IFlightSeat flightSeatRepository, IUnitOfWork unitOfWork)
    {
        _flightSeatRepository = flightSeatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightSeatCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.FlightSeat(request.FlightId, request.SeatNumber, request.CabinTypeId, request.SeatLocationTypeId, request.AvailabilityStatusId);

        await _flightSeatRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
