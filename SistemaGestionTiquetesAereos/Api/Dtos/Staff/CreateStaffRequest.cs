namespace AirlineTicketSystem.Api.Dtos.Staff;

public sealed record CreateStaffRequest(
    Guid PersonId,
    Guid StaffPositionId,
    string EmployeeCode);
