using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class GetFlightStatusesHandler : IRequestHandler<GetFlightStatusesQuery, IReadOnlyList<Domain.Entities.FlightStatus>>
{
    private readonly IFlightStatus _flightStatusRepository;

    public GetFlightStatusesHandler(IFlightStatus flightStatusRepository)
    {
        _flightStatusRepository = flightStatusRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.FlightStatus>> Handle(GetFlightStatusesQuery request, CancellationToken cancellationToken)
    {
        return _flightStatusRepository.GetAllAsync(cancellationToken);
    }
}
