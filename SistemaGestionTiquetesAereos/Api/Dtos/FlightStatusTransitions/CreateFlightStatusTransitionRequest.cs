namespace AirlineTicketSystem.Api.Dtos.FlightStatusTransitions;

public sealed record CreateFlightStatusTransitionRequest(
    Guid FlightId,
    Guid FromFlightStatusId,
    Guid ToFlightStatusId,
    DateTime ChangedAt);
