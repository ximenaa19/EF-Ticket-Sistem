namespace AirlineTicketSystem.Api.Dtos.Regions;

public sealed record RegionDto(
    Guid Id,
    string Name,
    Guid CountryId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
