using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class GetAirportAirlineByIdHandler : IRequestHandler<GetAirportAirlineByIdQuery, Domain.Entities.AirportAirline>
{
    private readonly IAirportAirline _airportAirlineRepository;

    public GetAirportAirlineByIdHandler(IAirportAirline airportAirlineRepository)
    {
        _airportAirlineRepository = airportAirlineRepository;
    }

    public async Task<Domain.Entities.AirportAirline> Handle(GetAirportAirlineByIdQuery request, CancellationToken cancellationToken)
    {
        return await _airportAirlineRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AirportAirline), request.Id);
    }
}
