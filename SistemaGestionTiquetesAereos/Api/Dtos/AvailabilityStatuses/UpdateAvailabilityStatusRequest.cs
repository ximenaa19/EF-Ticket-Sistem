namespace AirlineTicketSystem.Api.Dtos.AvailabilityStatuses;

public sealed record UpdateAvailabilityStatusRequest(
    string Name,
    bool IsActive);
