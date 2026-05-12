using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed record DeleteStaffPositionCommand(Guid Id) : IRequest;
