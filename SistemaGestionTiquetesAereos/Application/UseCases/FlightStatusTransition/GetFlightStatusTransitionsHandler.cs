using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class GetFlightStatusTransitionsHandler : IRequestHandler<GetFlightStatusTransitionsQuery, IReadOnlyList<Domain.Entities.FlightStatusTransition>>
{
    private readonly IFlightStatusTransition _flightStatusTransitionRepository;

    public GetFlightStatusTransitionsHandler(IFlightStatusTransition flightStatusTransitionRepository)
    {
        _flightStatusTransitionRepository = flightStatusTransitionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.FlightStatusTransition>> Handle(GetFlightStatusTransitionsQuery request, CancellationToken cancellationToken)
    {
        return _flightStatusTransitionRepository.GetAllAsync(cancellationToken);
    }
}
