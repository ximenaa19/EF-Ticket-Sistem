namespace AirlineTicketSystem.Api.Dtos.Airports;

public sealed record CreateAirportRequest(
    string Name,
    string IataCode,
    string IcaoCode,
    Guid CityId);
