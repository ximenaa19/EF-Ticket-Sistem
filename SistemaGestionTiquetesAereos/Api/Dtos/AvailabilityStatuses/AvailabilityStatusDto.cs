namespace AirlineTicketSystem.Api.Dtos.AvailabilityStatuses;

public sealed record AvailabilityStatusDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
