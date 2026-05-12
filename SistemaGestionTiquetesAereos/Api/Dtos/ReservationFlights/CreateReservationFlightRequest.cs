namespace AirlineTicketSystem.Api.Dtos.ReservationFlights;

public sealed record CreateReservationFlightRequest(
    Guid ReservationId,
    Guid FlightId);
