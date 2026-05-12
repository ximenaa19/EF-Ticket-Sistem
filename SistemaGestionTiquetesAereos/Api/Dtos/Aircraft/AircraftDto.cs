namespace AirlineTicketSystem.Api.Dtos.Aircraft;

public sealed record AircraftDto(
    Guid Id,
    string RegistrationNumber,
    Guid AirlineId,
    Guid AircraftModelId,
    Guid AvailabilityStatusId,
    int TotalCapacity,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
