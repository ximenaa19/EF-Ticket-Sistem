namespace AirlineTicketSystem.Api.Dtos.FlightSeats;

public sealed record CreateFlightSeatRequest(
    Guid FlightId,
    string SeatNumber,
    Guid CabinTypeId,
    Guid SeatLocationTypeId,
    Guid AvailabilityStatusId);
