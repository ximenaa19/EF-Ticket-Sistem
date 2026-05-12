namespace AirlineTicketSystem.Api.Dtos.ReservationStatuses;

public sealed record ReservationStatusDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
