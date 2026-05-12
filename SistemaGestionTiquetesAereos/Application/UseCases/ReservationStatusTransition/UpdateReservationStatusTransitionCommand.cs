using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed record UpdateReservationStatusTransitionCommand(Guid Id, Guid ReservationId,
    Guid FromReservationStatusId,
    Guid ToReservationStatusId,
    DateTime ChangedAt, bool IsActive) : IRequest;
