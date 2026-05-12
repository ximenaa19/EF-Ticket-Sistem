namespace AirlineTicketSystem.Api.Dtos.Regions;

public sealed record CreateRegionRequest(
    string Name,
    Guid CountryId);
