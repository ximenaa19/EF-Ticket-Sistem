using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class GetReservationStatusesHandler : IRequestHandler<GetReservationStatusesQuery, IReadOnlyList<Domain.Entities.ReservationStatus>>
{
    private readonly IReservationStatus _reservationStatusRepository;

    public GetReservationStatusesHandler(IReservationStatus reservationStatusRepository)
    {
        _reservationStatusRepository = reservationStatusRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.ReservationStatus>> Handle(GetReservationStatusesQuery request, CancellationToken cancellationToken)
    {
        return _reservationStatusRepository.GetAllAsync(cancellationToken);
    }
}
