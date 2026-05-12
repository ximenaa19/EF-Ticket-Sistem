using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed record GetRoleByIdQuery(Guid Id) : IRequest<Domain.Entities.Role>;
