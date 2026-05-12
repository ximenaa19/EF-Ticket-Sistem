namespace AirlineTicketSystem.Api.Dtos.Reservations;

public sealed record UpdateReservationRequest(
    Guid ClientId,
    Guid ReservationStatusId,
    string ReservationCode,
    DateTime ReservedAt,
    decimal TotalAmount,
    string Currency,
    bool IsActive);
