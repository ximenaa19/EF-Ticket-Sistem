namespace AirlineTicketSystem.Api.Dtos.Tickets;

public sealed record CreateTicketRequest(
    Guid ReservationId,
    Guid PassengerId,
    Guid FlightId,
    Guid TicketStatusId,
    string TicketNumber,
    decimal FareAmount,
    string Currency);
