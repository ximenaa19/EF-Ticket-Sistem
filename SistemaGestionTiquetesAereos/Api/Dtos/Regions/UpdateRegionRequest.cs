namespace AirlineTicketSystem.Api.Dtos.Regions;

public sealed record UpdateRegionRequest(
    string Name,
    Guid CountryId,
    bool IsActive);
