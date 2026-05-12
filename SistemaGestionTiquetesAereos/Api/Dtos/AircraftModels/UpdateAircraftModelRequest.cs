namespace AirlineTicketSystem.Api.Dtos.AircraftModels;

public sealed record UpdateAircraftModelRequest(
    string Name,
    Guid AircraftManufacturerId,
    bool IsActive);
