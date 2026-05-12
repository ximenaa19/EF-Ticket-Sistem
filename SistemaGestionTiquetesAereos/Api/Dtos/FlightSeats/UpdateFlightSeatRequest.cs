namespace AirlineTicketSystem.Api.Dtos.FlightSeats;

public sealed record UpdateFlightSeatRequest(
    Guid FlightId,
    string SeatNumber,
    Guid CabinTypeId,
    Guid SeatLocationTypeId,
    Guid AvailabilityStatusId,
    bool IsActive);
