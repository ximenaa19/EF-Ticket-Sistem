using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed record UpdateFlightSeatCommand(Guid Id, Guid FlightId,
    string SeatNumber,
    Guid CabinTypeId,
    Guid SeatLocationTypeId,
    Guid AvailabilityStatusId, bool IsActive) : IRequest;
