using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed record GetRolesQuery : IRequest<IReadOnlyList<Domain.Entities.Role>>;
