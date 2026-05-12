using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Domain.Entities.Country>
{
    private readonly ICountry _countryRepository;

    public GetCountryByIdHandler(ICountry countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Domain.Entities.Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Country), request.Id);
    }
}
