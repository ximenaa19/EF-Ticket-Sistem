using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed record DeleteReservationPassengerCommand(Guid Id) : IRequest;
