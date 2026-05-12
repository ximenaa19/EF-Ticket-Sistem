using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed record GetReservationPassengerByIdQuery(Guid Id) : IRequest<Domain.Entities.ReservationPassenger>;
