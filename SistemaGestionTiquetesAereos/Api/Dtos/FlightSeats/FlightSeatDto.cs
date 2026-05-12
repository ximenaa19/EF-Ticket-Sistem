namespace AirlineTicketSystem.Api.Dtos.FlightSeats;

public sealed record FlightSeatDto(
    Guid Id,
    Guid FlightId,
    string SeatNumber,
    Guid CabinTypeId,
    Guid SeatLocationTypeId,
    Guid AvailabilityStatusId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
