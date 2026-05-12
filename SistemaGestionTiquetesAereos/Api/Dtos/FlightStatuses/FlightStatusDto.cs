namespace AirlineTicketSystem.Api.Dtos.FlightStatuses;

public sealed record FlightStatusDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
