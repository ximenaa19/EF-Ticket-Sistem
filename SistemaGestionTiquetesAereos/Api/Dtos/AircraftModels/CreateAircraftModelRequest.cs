namespace AirlineTicketSystem.Api.Dtos.AircraftModels;

public sealed record CreateAircraftModelRequest(
    string Name,
    Guid AircraftManufacturerId);
