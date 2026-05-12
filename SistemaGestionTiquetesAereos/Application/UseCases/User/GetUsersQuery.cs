using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed record GetUsersQuery : IRequest<IReadOnlyList<Domain.Entities.User>>;
