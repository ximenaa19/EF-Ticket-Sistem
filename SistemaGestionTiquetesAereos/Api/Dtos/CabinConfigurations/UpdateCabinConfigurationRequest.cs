namespace AirlineTicketSystem.Api.Dtos.CabinConfigurations;

public sealed record UpdateCabinConfigurationRequest(
    Guid AircraftId,
    Guid CabinTypeId,
    int SeatCount,
    bool IsActive);
