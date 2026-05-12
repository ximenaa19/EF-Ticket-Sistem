namespace AirlineTicketSystem.Api.Dtos.AircraftManufacturers;

public sealed record AircraftManufacturerDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
