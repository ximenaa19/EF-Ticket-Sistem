namespace AirlineTicketSystem.Api.Dtos.Cities;

public sealed record CreateCityRequest(
    string Name,
    Guid RegionId);
