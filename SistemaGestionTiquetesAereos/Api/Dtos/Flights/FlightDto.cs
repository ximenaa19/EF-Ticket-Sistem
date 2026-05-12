namespace AirlineTicketSystem.Api.Dtos.Flights;

public sealed record FlightDto(
    Guid Id,
    string FlightCode,
    Guid AirlineId,
    Guid RouteId,
    Guid AircraftId,
    DateTime DepartureDate,
    DateTime EstimatedArrivalDate,
    int TotalCapacity,
    int AvailableSeats,
    Guid FlightStatusId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
