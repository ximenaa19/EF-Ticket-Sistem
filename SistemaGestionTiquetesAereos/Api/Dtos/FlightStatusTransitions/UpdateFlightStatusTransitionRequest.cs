namespace AirlineTicketSystem.Api.Dtos.FlightStatusTransitions;

public sealed record UpdateFlightStatusTransitionRequest(
    Guid FlightId,
    Guid FromFlightStatusId,
    Guid ToFlightStatusId,
    DateTime ChangedAt,
    bool IsActive);
