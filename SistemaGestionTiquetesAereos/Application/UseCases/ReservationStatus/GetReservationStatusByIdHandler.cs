using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class GetReservationStatusByIdHandler : IRequestHandler<GetReservationStatusByIdQuery, Domain.Entities.ReservationStatus>
{
    private readonly IReservationStatus _reservationStatusRepository;

    public GetReservationStatusByIdHandler(IReservationStatus reservationStatusRepository)
    {
        _reservationStatusRepository = reservationStatusRepository;
    }

    public async Task<Domain.Entities.ReservationStatus> Handle(GetReservationStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _reservationStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationStatus), request.Id);
    }
}
