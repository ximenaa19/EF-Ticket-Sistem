using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed class GetReservationByIdHandler : IRequestHandler<GetReservationByIdQuery, Domain.Entities.Reservation>
{
    private readonly IReservation _reservationRepository;

    public GetReservationByIdHandler(IReservation reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Domain.Entities.Reservation> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _reservationRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Reservation), request.Id);
    }
}
