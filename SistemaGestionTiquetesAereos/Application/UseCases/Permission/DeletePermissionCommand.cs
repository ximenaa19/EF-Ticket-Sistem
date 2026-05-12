using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed record DeletePermissionCommand(Guid Id) : IRequest;
