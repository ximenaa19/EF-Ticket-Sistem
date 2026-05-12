using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed record UpdateStaffPositionCommand(Guid Id, string Name, bool IsActive) : IRequest;
