using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed record GetCardIssuersQuery : IRequest<IReadOnlyList<Domain.Entities.CardIssuer>>;
