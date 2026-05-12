using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed record UpdateReservationPassengerCommand(Guid Id, Guid ReservationId,
    Guid PassengerId, bool IsActive) : IRequest;
