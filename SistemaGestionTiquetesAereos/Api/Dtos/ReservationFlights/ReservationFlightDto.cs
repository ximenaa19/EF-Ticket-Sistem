namespace AirlineTicketSystem.Api.Dtos.ReservationFlights;

public sealed record ReservationFlightDto(
    Guid Id,
    Guid ReservationId,
    Guid FlightId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
