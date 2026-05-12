namespace AirlineTicketSystem.Api.Dtos.Countries;

public sealed record CreateCountryRequest(
    string Name,
    string IsoCode,
    Guid ContinentId);
