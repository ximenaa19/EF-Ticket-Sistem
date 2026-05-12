using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class GetFlightSeatByIdHandler : IRequestHandler<GetFlightSeatByIdQuery, Domain.Entities.FlightSeat>
{
    private readonly IFlightSeat _flightSeatRepository;

    public GetFlightSeatByIdHandler(IFlightSeat flightSeatRepository)
    {
        _flightSeatRepository = flightSeatRepository;
    }

    public async Task<Domain.Entities.FlightSeat> Handle(GetFlightSeatByIdQuery request, CancellationToken cancellationToken)
    {
        return await _flightSeatRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightSeat), request.Id);
    }
}
