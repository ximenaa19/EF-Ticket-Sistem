using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed record CreateSessionCommand(Guid UserId,
    string Token,
    DateTime ExpiresAt,
    DateTime? RevokedAt) : IRequest<Guid>;
