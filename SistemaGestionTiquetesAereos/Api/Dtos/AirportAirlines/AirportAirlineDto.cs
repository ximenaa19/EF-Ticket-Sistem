namespace AirlineTicketSystem.Api.Dtos.AirportAirlines;

public sealed record AirportAirlineDto(
    Guid Id,
    Guid AirportId,
    Guid AirlineId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
