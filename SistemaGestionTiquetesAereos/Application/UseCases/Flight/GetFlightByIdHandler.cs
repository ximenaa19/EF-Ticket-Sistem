using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed class GetFlightByIdHandler : IRequestHandler<GetFlightByIdQuery, Domain.Entities.Flight>
{
    private readonly IFlight _flightRepository;

    public GetFlightByIdHandler(IFlight flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<Domain.Entities.Flight> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        return await _flightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Flight), request.Id);
    }
}
