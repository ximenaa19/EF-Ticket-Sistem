namespace AirlineTicketSystem.Api.Dtos.Staff;

public sealed record StaffDto(
    Guid Id,
    Guid PersonId,
    Guid StaffPositionId,
    string EmployeeCode,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
