namespace AirlineTicketSystem.Api.Dtos.PassengerTypes;

public sealed record UpdatePassengerTypeRequest(
    string Name,
    bool IsActive);
