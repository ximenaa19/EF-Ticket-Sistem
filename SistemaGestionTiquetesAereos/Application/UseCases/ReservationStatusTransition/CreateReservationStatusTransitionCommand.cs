using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed record CreateReservationStatusTransitionCommand(Guid ReservationId,
    Guid FromReservationStatusId,
    Guid ToReservationStatusId,
    DateTime ChangedAt) : IRequest<Guid>;
