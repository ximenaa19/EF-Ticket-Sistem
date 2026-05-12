using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed record GetPermissionsQuery : IRequest<IReadOnlyList<Domain.Entities.Permission>>;
