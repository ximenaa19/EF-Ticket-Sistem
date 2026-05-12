namespace AirlineTicketSystem.Api.Dtos.SeatLocationTypes;

public sealed record UpdateSeatLocationTypeRequest(
    string Name,
    bool IsActive);
