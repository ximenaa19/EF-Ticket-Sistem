using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class GetFlightStatusByIdHandler : IRequestHandler<GetFlightStatusByIdQuery, Domain.Entities.FlightStatus>
{
    private readonly IFlightStatus _flightStatusRepository;

    public GetFlightStatusByIdHandler(IFlightStatus flightStatusRepository)
    {
        _flightStatusRepository = flightStatusRepository;
    }

    public async Task<Domain.Entities.FlightStatus> Handle(GetFlightStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _flightStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightStatus), request.Id);
    }
}
