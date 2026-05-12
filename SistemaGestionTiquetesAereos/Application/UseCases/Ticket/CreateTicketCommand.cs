using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed record CreateTicketCommand(Guid ReservationId,
    Guid PassengerId,
    Guid FlightId,
    Guid TicketStatusId,
    string TicketNumber,
    decimal FareAmount,
    string Currency) : IRequest<Guid>;
