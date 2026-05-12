namespace AirlineTicketSystem.Api.Dtos.CheckInStatuses;

public sealed record UpdateCheckInStatusRequest(
    string Name,
    bool IsActive);
