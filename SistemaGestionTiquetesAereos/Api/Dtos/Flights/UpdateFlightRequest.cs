namespace AirlineTicketSystem.Api.Dtos.Flights;

public sealed record UpdateFlightRequest(
    string FlightCode,
    Guid AirlineId,
    Guid RouteId,
    Guid AircraftId,
    DateTime DepartureDate,
    DateTime EstimatedArrivalDate,
    int TotalCapacity,
    int AvailableSeats,
    Guid FlightStatusId,
    bool IsActive);
