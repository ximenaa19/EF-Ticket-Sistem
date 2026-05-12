namespace AirlineTicketSystem.Api.Dtos.AircraftManufacturers;

public sealed record UpdateAircraftManufacturerRequest(
    string Name,
    bool IsActive);
