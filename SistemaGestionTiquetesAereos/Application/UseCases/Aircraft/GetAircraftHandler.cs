using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed class GetAircraftHandler : IRequestHandler<GetAircraftQuery, IReadOnlyList<Domain.Entities.Aircraft>>
{
    private readonly IAircraft _aircraftRepository;

    public GetAircraftHandler(IAircraft aircraftRepository)
    {
        _aircraftRepository = aircraftRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Aircraft>> Handle(GetAircraftQuery request, CancellationToken cancellationToken)
    {
        return _aircraftRepository.GetAllAsync(cancellationToken);
    }
}
