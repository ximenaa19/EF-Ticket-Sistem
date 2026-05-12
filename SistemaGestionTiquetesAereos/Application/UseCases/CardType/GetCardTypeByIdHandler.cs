using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class GetCardTypeByIdHandler : IRequestHandler<GetCardTypeByIdQuery, Domain.Entities.CardType>
{
    private readonly ICardType _cardTypeRepository;

    public GetCardTypeByIdHandler(ICardType cardTypeRepository)
    {
        _cardTypeRepository = cardTypeRepository;
    }

    public async Task<Domain.Entities.CardType> Handle(GetCardTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _cardTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CardType), request.Id);
    }
}
