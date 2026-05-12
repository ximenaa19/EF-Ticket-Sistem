using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed class GetAirportByIdHandler : IRequestHandler<GetAirportByIdQuery, Domain.Entities.Airport>
{
    private readonly IAirport _airportRepository;

    public GetAirportByIdHandler(IAirport airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<Domain.Entities.Airport> Handle(GetAirportByIdQuery request, CancellationToken cancellationToken)
    {
        return await _airportRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Airport), request.Id);
    }
}
