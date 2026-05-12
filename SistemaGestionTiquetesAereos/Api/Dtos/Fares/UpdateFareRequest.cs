namespace AirlineTicketSystem.Api.Dtos.Fares;

public sealed record UpdateFareRequest(
    Guid FlightId,
    Guid PassengerTypeId,
    Guid CabinTypeId,
    decimal Amount,
    string Currency,
    bool IsActive);
