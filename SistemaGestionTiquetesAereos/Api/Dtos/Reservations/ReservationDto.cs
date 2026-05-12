namespace AirlineTicketSystem.Api.Dtos.Reservations;

public sealed record ReservationDto(
    Guid Id,
    Guid ClientId,
    Guid ReservationStatusId,
    string ReservationCode,
    DateTime ReservedAt,
    decimal TotalAmount,
    string Currency,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
