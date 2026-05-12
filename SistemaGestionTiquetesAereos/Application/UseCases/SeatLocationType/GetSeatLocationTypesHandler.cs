using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class GetSeatLocationTypesHandler : IRequestHandler<GetSeatLocationTypesQuery, IReadOnlyList<Domain.Entities.SeatLocationType>>
{
    private readonly ISeatLocationType _seatLocationTypeRepository;

    public GetSeatLocationTypesHandler(ISeatLocationType seatLocationTypeRepository)
    {
        _seatLocationTypeRepository = seatLocationTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.SeatLocationType>> Handle(GetSeatLocationTypesQuery request, CancellationToken cancellationToken)
    {
        return _seatLocationTypeRepository.GetAllAsync(cancellationToken);
    }
}
