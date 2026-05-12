namespace AirlineTicketSystem.Api.Dtos.Countries;

public sealed record CountryDto(
    Guid Id,
    string Name,
    string IsoCode,
    Guid ContinentId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
