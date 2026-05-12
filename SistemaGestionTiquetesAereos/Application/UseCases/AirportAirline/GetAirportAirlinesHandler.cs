using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class GetAirportAirlinesHandler : IRequestHandler<GetAirportAirlinesQuery, IReadOnlyList<Domain.Entities.AirportAirline>>
{
    private readonly IAirportAirline _airportAirlineRepository;

    public GetAirportAirlinesHandler(IAirportAirline airportAirlineRepository)
    {
        _airportAirlineRepository = airportAirlineRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.AirportAirline>> Handle(GetAirportAirlinesQuery request, CancellationToken cancellationToken)
    {
        return _airportAirlineRepository.GetAllAsync(cancellationToken);
    }
}
