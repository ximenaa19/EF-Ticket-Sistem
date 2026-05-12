using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed record GetSessionsQuery : IRequest<IReadOnlyList<Domain.Entities.Session>>;
