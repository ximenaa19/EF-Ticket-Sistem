namespace AirlineTicketSystem.Api.Dtos.CheckIns;

public sealed record UpdateCheckInRequest(
    Guid TicketId,
    Guid CheckInStatusId,
    Guid? SeatId,
    DateTime CheckedInAt,
    bool IsActive);
