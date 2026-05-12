namespace AirlineTicketSystem.Api.Dtos.RoadTypes;

public sealed record RoadTypeDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
