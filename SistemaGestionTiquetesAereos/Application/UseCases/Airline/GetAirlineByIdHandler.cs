using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed class GetAirlineByIdHandler : IRequestHandler<GetAirlineByIdQuery, Domain.Entities.Airline>
{
    private readonly IAirline _airlineRepository;

    public GetAirlineByIdHandler(IAirline airlineRepository)
    {
        _airlineRepository = airlineRepository;
    }

    public async Task<Domain.Entities.Airline> Handle(GetAirlineByIdQuery request, CancellationToken cancellationToken)
    {
        return await _airlineRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Airline), request.Id);
    }
}
