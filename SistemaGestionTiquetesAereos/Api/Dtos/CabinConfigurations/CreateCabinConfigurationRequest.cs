namespace AirlineTicketSystem.Api.Dtos.CabinConfigurations;

public sealed record CreateCabinConfigurationRequest(
    Guid AircraftId,
    Guid CabinTypeId,
    int SeatCount);
