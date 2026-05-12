using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class GetReservationStatusTransitionsHandler : IRequestHandler<GetReservationStatusTransitionsQuery, IReadOnlyList<Domain.Entities.ReservationStatusTransition>>
{
    private readonly IReservationStatusTransition _reservationStatusTransitionRepository;

    public GetReservationStatusTransitionsHandler(IReservationStatusTransition reservationStatusTransitionRepository)
    {
        _reservationStatusTransitionRepository = reservationStatusTransitionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.ReservationStatusTransition>> Handle(GetReservationStatusTransitionsQuery request, CancellationToken cancellationToken)
    {
        return _reservationStatusTransitionRepository.GetAllAsync(cancellationToken);
    }
}
