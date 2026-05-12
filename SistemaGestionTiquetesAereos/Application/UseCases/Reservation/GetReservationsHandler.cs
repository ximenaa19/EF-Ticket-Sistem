using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed class GetReservationsHandler : IRequestHandler<GetReservationsQuery, IReadOnlyList<Domain.Entities.Reservation>>
{
    private readonly IReservation _reservationRepository;

    public GetReservationsHandler(IReservation reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Reservation>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        return _reservationRepository.GetAllAsync(cancellationToken);
    }
}
