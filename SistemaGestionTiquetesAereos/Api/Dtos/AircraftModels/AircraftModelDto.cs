namespace AirlineTicketSystem.Api.Dtos.AircraftModels;

public sealed record AircraftModelDto(
    Guid Id,
    string Name,
    Guid AircraftManufacturerId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
