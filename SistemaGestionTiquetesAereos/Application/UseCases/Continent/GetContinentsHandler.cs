using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class GetContinentsHandler : IRequestHandler<GetContinentsQuery, IReadOnlyList<Domain.Entities.Continent>>
{
    private readonly IContinent _continentRepository;

    public GetContinentsHandler(IContinent continentRepository)
    {
        _continentRepository = continentRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Continent>> Handle(GetContinentsQuery request, CancellationToken cancellationToken)
    {
        return _continentRepository.GetAllAsync(cancellationToken);
    }
}
