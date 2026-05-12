namespace AirlineTicketSystem.Api.Dtos.Airports;

public sealed record UpdateAirportRequest(
    string Name,
    string IataCode,
    string IcaoCode,
    Guid CityId,
    bool IsActive);
