using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed record CreateStaffPositionCommand(string Name) : IRequest<Guid>;
