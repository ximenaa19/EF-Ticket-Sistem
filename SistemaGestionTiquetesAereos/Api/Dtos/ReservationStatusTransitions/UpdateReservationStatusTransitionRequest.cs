namespace AirlineTicketSystem.Api.Dtos.ReservationStatusTransitions;

public sealed record UpdateReservationStatusTransitionRequest(
    Guid ReservationId,
    Guid FromReservationStatusId,
    Guid ToReservationStatusId,
    DateTime ChangedAt,
    bool IsActive);
