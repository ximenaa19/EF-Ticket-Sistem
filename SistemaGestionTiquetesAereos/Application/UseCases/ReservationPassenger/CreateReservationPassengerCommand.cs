using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed record CreateReservationPassengerCommand(Guid ReservationId,
    Guid PassengerId) : IRequest<Guid>;
