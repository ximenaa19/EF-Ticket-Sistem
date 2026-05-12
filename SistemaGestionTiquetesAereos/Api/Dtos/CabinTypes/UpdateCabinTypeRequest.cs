namespace AirlineTicketSystem.Api.Dtos.CabinTypes;

public sealed record UpdateCabinTypeRequest(
    string Name,
    bool IsActive);
