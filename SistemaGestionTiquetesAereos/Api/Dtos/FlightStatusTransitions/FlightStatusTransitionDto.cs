namespace AirlineTicketSystem.Api.Dtos.FlightStatusTransitions;

public sealed record FlightStatusTransitionDto(
    Guid Id,
    Guid FlightId,
    Guid FromFlightStatusId,
    Guid ToFlightStatusId,
    DateTime ChangedAt,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
