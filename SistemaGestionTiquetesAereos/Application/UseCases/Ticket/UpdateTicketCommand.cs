using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed record UpdateTicketCommand(Guid Id, Guid ReservationId,
    Guid PassengerId,
    Guid FlightId,
    Guid TicketStatusId,
    string TicketNumber,
    decimal FareAmount,
    string Currency, bool IsActive) : IRequest;
