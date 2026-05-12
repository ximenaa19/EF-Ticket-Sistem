namespace AirlineTicketSystem.Api.Dtos.Cities;

public sealed record CityDto(
    Guid Id,
    string Name,
    Guid RegionId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
