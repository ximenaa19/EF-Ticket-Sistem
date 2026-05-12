namespace AirlineTicketSystem.Api.Dtos.Fares;

public sealed record CreateFareRequest(
    Guid FlightId,
    Guid PassengerTypeId,
    Guid CabinTypeId,
    decimal Amount,
    string Currency);
