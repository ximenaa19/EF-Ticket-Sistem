namespace AirlineTicketSystem.Api.Dtos.Aircraft;

public sealed record UpdateAircraftRequest(
    string RegistrationNumber,
    Guid AirlineId,
    Guid AircraftModelId,
    Guid AvailabilityStatusId,
    int TotalCapacity,
    bool IsActive);
