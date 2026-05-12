namespace AirlineTicketSystem.Api.Dtos.Passengers;

public sealed record CreatePassengerRequest(
    Guid PersonId,
    Guid PassengerTypeId);
