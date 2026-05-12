using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class GetFlightStatusTransitionByIdHandler : IRequestHandler<GetFlightStatusTransitionByIdQuery, Domain.Entities.FlightStatusTransition>
{
    private readonly IFlightStatusTransition _flightStatusTransitionRepository;

    public GetFlightStatusTransitionByIdHandler(IFlightStatusTransition flightStatusTransitionRepository)
    {
        _flightStatusTransitionRepository = flightStatusTransitionRepository;
    }

    public async Task<Domain.Entities.FlightStatusTransition> Handle(GetFlightStatusTransitionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _flightStatusTransitionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightStatusTransition), request.Id);
    }
}
