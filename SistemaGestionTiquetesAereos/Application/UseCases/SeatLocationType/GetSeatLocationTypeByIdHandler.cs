using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class GetSeatLocationTypeByIdHandler : IRequestHandler<GetSeatLocationTypeByIdQuery, Domain.Entities.SeatLocationType>
{
    private readonly ISeatLocationType _seatLocationTypeRepository;

    public GetSeatLocationTypeByIdHandler(ISeatLocationType seatLocationTypeRepository)
    {
        _seatLocationTypeRepository = seatLocationTypeRepository;
    }

    public async Task<Domain.Entities.SeatLocationType> Handle(GetSeatLocationTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _seatLocationTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.SeatLocationType), request.Id);
    }
}
