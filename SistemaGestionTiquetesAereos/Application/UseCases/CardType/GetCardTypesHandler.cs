using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class GetCardTypesHandler : IRequestHandler<GetCardTypesQuery, IReadOnlyList<Domain.Entities.CardType>>
{
    private readonly ICardType _cardTypeRepository;

    public GetCardTypesHandler(ICardType cardTypeRepository)
    {
        _cardTypeRepository = cardTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.CardType>> Handle(GetCardTypesQuery request, CancellationToken cancellationToken)
    {
        return _cardTypeRepository.GetAllAsync(cancellationToken);
    }
}
