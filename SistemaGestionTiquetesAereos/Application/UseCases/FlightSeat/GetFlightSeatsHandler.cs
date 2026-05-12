using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class GetFlightSeatsHandler : IRequestHandler<GetFlightSeatsQuery, IReadOnlyList<Domain.Entities.FlightSeat>>
{
    private readonly IFlightSeat _flightSeatRepository;

    public GetFlightSeatsHandler(IFlightSeat flightSeatRepository)
    {
        _flightSeatRepository = flightSeatRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.FlightSeat>> Handle(GetFlightSeatsQuery request, CancellationToken cancellationToken)
    {
        return _flightSeatRepository.GetAllAsync(cancellationToken);
    }
}
