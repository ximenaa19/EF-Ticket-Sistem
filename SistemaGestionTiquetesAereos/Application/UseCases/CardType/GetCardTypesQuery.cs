using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed record GetCardTypesQuery : IRequest<IReadOnlyList<Domain.Entities.CardType>>;
