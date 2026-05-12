namespace AirlineTicketSystem.Api.Dtos.Tickets;

public sealed record TicketDto(
    Guid Id,
    Guid ReservationId,
    Guid PassengerId,
    Guid FlightId,
    Guid TicketStatusId,
    string TicketNumber,
    decimal FareAmount,
    string Currency,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
