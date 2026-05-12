using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed record UpdateStaffCommand(Guid Id, Guid PersonId,
    Guid StaffPositionId,
    string EmployeeCode, bool IsActive) : IRequest;
