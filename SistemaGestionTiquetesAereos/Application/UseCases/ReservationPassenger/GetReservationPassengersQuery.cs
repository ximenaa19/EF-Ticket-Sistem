using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed record GetReservationPassengersQuery : IRequest<IReadOnlyList<Domain.Entities.ReservationPassenger>>;
