using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed record DeleteStaffCommand(Guid Id) : IRequest;
