using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class GetReservationStatusTransitionByIdHandler : IRequestHandler<GetReservationStatusTransitionByIdQuery, Domain.Entities.ReservationStatusTransition>
{
    private readonly IReservationStatusTransition _reservationStatusTransitionRepository;

    public GetReservationStatusTransitionByIdHandler(IReservationStatusTransition reservationStatusTransitionRepository)
    {
        _reservationStatusTransitionRepository = reservationStatusTransitionRepository;
    }

    public async Task<Domain.Entities.ReservationStatusTransition> Handle(GetReservationStatusTransitionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _reservationStatusTransitionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationStatusTransition), request.Id);
    }
}
