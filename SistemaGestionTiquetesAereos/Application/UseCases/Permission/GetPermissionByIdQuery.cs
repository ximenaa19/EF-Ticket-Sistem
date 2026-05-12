using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed record GetPermissionByIdQuery(Guid Id) : IRequest<Domain.Entities.Permission>;
