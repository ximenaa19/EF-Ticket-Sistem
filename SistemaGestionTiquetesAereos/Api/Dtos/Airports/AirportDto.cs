namespace AirlineTicketSystem.Api.Dtos.Airports;

public sealed record AirportDto(
    Guid Id,
    string Name,
    string IataCode,
    string IcaoCode,
    Guid CityId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
