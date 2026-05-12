namespace AirlineTicketSystem.Api.Dtos.ReservationFlights;

public sealed record UpdateReservationFlightRequest(
    Guid ReservationId,
    Guid FlightId,
    bool IsActive);
