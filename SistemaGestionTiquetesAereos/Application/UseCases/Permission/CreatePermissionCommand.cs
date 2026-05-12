using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed record CreatePermissionCommand(string Name,
    string Code) : IRequest<Guid>;
