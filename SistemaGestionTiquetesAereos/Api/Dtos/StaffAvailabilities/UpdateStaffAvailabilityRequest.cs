namespace AirlineTicketSystem.Api.Dtos.StaffAvailabilities;

public sealed record UpdateStaffAvailabilityRequest(
    Guid StaffId,
    Guid AvailabilityStatusId,
    DateTime AvailableFrom,
    DateTime AvailableTo,
    bool IsActive);
