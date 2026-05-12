using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IReadOnlyList<Domain.Entities.Country>>
{
    private readonly ICountry _countryRepository;

    public GetCountriesHandler(ICountry countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Country>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return _countryRepository.GetAllAsync(cancellationToken);
    }
}
