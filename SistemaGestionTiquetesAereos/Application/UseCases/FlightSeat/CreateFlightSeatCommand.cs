using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed record CreateFlightSeatCommand(Guid FlightId,
    string SeatNumber,
    Guid CabinTypeId,
    Guid SeatLocationTypeId,
    Guid AvailabilityStatusId) : IRequest<Guid>;
