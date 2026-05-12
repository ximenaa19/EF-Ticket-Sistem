namespace AirlineTicketSystem.Api.Dtos.StaffAvailabilities;

public sealed record CreateStaffAvailabilityRequest(
    Guid StaffId,
    Guid AvailabilityStatusId,
    DateTime AvailableFrom,
    DateTime AvailableTo);
