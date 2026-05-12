using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class GetReservationPassengerByIdHandler : IRequestHandler<GetReservationPassengerByIdQuery, Domain.Entities.ReservationPassenger>
{
    private readonly IReservationPassenger _reservationPassengerRepository;

    public GetReservationPassengerByIdHandler(IReservationPassenger reservationPassengerRepository)
    {
        _reservationPassengerRepository = reservationPassengerRepository;
    }

    public async Task<Domain.Entities.ReservationPassenger> Handle(GetReservationPassengerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _reservationPassengerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationPassenger), request.Id);
    }
}
