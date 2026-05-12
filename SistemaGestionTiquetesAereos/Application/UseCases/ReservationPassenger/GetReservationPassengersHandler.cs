using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class GetReservationPassengersHandler : IRequestHandler<GetReservationPassengersQuery, IReadOnlyList<Domain.Entities.ReservationPassenger>>
{
    private readonly IReservationPassenger _reservationPassengerRepository;

    public GetReservationPassengersHandler(IReservationPassenger reservationPassengerRepository)
    {
        _reservationPassengerRepository = reservationPassengerRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.ReservationPassenger>> Handle(GetReservationPassengersQuery request, CancellationToken cancellationToken)
    {
        return _reservationPassengerRepository.GetAllAsync(cancellationToken);
    }
}
