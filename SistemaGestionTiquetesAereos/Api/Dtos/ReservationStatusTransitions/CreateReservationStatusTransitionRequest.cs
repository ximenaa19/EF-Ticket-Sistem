namespace AirlineTicketSystem.Api.Dtos.ReservationStatusTransitions;

public sealed record CreateReservationStatusTransitionRequest(
    Guid ReservationId,
    Guid FromReservationStatusId,
    Guid ToReservationStatusId,
    DateTime ChangedAt);
