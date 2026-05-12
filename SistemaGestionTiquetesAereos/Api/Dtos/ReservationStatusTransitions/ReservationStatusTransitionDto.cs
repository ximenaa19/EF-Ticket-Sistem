namespace AirlineTicketSystem.Api.Dtos.ReservationStatusTransitions;

public sealed record ReservationStatusTransitionDto(
    Guid Id,
    Guid ReservationId,
    Guid FromReservationStatusId,
    Guid ToReservationStatusId,
    DateTime ChangedAt,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
