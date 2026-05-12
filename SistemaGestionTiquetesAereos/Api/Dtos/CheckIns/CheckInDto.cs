namespace AirlineTicketSystem.Api.Dtos.CheckIns;

public sealed record CheckInDto(
    Guid Id,
    Guid TicketId,
    Guid CheckInStatusId,
    Guid? SeatId,
    DateTime CheckedInAt,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
