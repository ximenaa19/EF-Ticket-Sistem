namespace AirlineTicketSystem.Api.Dtos.Aircraft;

public sealed record CreateAircraftRequest(
    string RegistrationNumber,
    Guid AirlineId,
    Guid AircraftModelId,
    Guid AvailabilityStatusId,
    int TotalCapacity);
