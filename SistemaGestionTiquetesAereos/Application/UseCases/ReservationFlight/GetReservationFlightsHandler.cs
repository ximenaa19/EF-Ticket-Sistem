using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class GetReservationFlightsHandler : IRequestHandler<GetReservationFlightsQuery, IReadOnlyList<Domain.Entities.ReservationFlight>>
{
    private readonly IReservationFlight _reservationFlightRepository;

    public GetReservationFlightsHandler(IReservationFlight reservationFlightRepository)
    {
        _reservationFlightRepository = reservationFlightRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.ReservationFlight>> Handle(GetReservationFlightsQuery request, CancellationToken cancellationToken)
    {
        return _reservationFlightRepository.GetAllAsync(cancellationToken);
    }
}
