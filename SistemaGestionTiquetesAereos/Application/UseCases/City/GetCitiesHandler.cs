using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IReadOnlyList<Domain.Entities.City>>
{
    private readonly ICity _cityRepository;

    public GetCitiesHandler(ICity cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.City>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        return _cityRepository.GetAllAsync(cancellationToken);
    }
}
