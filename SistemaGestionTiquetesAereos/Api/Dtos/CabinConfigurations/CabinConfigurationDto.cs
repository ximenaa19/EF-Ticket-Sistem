namespace AirlineTicketSystem.Api.Dtos.CabinConfigurations;

public sealed record CabinConfigurationDto(
    Guid Id,
    Guid AircraftId,
    Guid CabinTypeId,
    int SeatCount,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
