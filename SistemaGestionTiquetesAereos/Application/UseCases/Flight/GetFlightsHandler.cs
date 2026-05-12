using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed class GetFlightsHandler : IRequestHandler<GetFlightsQuery, IReadOnlyList<Domain.Entities.Flight>>
{
    private readonly IFlight _flightRepository;

    public GetFlightsHandler(IFlight flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Flight>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
    {
        return _flightRepository.GetAllAsync(cancellationToken);
    }
}
