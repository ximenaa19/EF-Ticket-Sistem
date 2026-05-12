namespace AirlineTicketSystem.Api.Dtos.Staff;

public sealed record UpdateStaffRequest(
    Guid PersonId,
    Guid StaffPositionId,
    string EmployeeCode,
    bool IsActive);
