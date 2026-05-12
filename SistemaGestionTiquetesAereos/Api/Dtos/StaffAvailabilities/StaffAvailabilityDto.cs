namespace AirlineTicketSystem.Api.Dtos.StaffAvailabilities;

public sealed record StaffAvailabilityDto(
    Guid Id,
    Guid StaffId,
    Guid AvailabilityStatusId,
    DateTime AvailableFrom,
    DateTime AvailableTo,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
