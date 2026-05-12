using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class GetCardIssuersHandler : IRequestHandler<GetCardIssuersQuery, IReadOnlyList<Domain.Entities.CardIssuer>>
{
    private readonly ICardIssuer _cardIssuerRepository;

    public GetCardIssuersHandler(ICardIssuer cardIssuerRepository)
    {
        _cardIssuerRepository = cardIssuerRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.CardIssuer>> Handle(GetCardIssuersQuery request, CancellationToken cancellationToken)
    {
        return _cardIssuerRepository.GetAllAsync(cancellationToken);
    }
}
