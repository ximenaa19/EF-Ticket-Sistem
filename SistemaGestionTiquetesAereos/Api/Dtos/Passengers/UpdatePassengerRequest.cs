namespace AirlineTicketSystem.Api.Dtos.Passengers;

public sealed record UpdatePassengerRequest(
    Guid PersonId,
    Guid PassengerTypeId,
    bool IsActive);
