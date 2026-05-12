using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class GetReservationFlightByIdHandler : IRequestHandler<GetReservationFlightByIdQuery, Domain.Entities.ReservationFlight>
{
    private readonly IReservationFlight _reservationFlightRepository;

    public GetReservationFlightByIdHandler(IReservationFlight reservationFlightRepository)
    {
        _reservationFlightRepository = reservationFlightRepository;
    }

    public async Task<Domain.Entities.ReservationFlight> Handle(GetReservationFlightByIdQuery request, CancellationToken cancellationToken)
    {
        return await _reservationFlightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationFlight), request.Id);
    }
}
