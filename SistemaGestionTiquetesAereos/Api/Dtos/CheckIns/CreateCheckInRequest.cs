namespace AirlineTicketSystem.Api.Dtos.CheckIns;

public sealed record CreateCheckInRequest(
    Guid TicketId,
    Guid CheckInStatusId,
    Guid? SeatId,
    DateTime CheckedInAt);
