namespace AirlineTicketSystem.Api.Dtos.Countries;

public sealed record UpdateCountryRequest(
    string Name,
    string IsoCode,
    Guid ContinentId,
    bool IsActive);
