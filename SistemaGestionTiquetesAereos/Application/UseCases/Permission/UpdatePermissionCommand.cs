using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed record UpdatePermissionCommand(Guid Id, string Name,
    string Code, bool IsActive) : IRequest;
