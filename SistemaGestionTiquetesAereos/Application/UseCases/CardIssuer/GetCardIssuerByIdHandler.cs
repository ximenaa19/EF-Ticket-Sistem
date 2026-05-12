using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class GetCardIssuerByIdHandler : IRequestHandler<GetCardIssuerByIdQuery, Domain.Entities.CardIssuer>
{
    private readonly ICardIssuer _cardIssuerRepository;

    public GetCardIssuerByIdHandler(ICardIssuer cardIssuerRepository)
    {
        _cardIssuerRepository = cardIssuerRepository;
    }

    public async Task<Domain.Entities.CardIssuer> Handle(GetCardIssuerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _cardIssuerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CardIssuer), request.Id);
    }
}
