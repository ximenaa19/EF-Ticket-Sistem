using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed class GetAirportsHandler : IRequestHandler<GetAirportsQuery, IReadOnlyList<Domain.Entities.Airport>>
{
    private readonly IAirport _airportRepository;

    public GetAirportsHandler(IAirport airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Airport>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
    {
        return _airportRepository.GetAllAsync(cancellationToken);
    }
}
