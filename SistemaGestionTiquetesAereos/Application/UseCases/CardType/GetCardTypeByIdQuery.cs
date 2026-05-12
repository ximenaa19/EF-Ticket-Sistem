using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed record GetCardTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.CardType>;
