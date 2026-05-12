namespace AirlineTicketSystem.Api.Dtos.Fares;

public sealed record FareDto(
    Guid Id,
    Guid FlightId,
    Guid PassengerTypeId,
    Guid CabinTypeId,
    decimal Amount,
    string Currency,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
