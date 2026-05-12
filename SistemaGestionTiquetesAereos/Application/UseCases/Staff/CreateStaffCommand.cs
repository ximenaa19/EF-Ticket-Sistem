using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed record CreateStaffCommand(Guid PersonId,
    Guid StaffPositionId,
    string EmployeeCode) : IRequest<Guid>;
