namespace AirlineTicketSystem.Api.Dtos.Cities;

public sealed record UpdateCityRequest(
    string Name,
    Guid RegionId,
    bool IsActive);
