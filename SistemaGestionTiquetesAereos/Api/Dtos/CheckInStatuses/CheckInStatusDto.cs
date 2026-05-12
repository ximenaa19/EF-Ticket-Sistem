namespace AirlineTicketSystem.Api.Dtos.CheckInStatuses;

public sealed record CheckInStatusDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
