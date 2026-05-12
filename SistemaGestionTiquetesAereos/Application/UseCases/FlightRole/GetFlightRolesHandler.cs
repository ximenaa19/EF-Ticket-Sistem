using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class GetFlightRolesHandler : IRequestHandler<GetFlightRolesQuery, IReadOnlyList<Domain.Entities.FlightRole>>
{
    private readonly IFlightRole _flightRoleRepository;

    public GetFlightRolesHandler(IFlightRole flightRoleRepository)
    {
        _flightRoleRepository = flightRoleRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.FlightRole>> Handle(GetFlightRolesQuery request, CancellationToken cancellationToken)
    {
        return _flightRoleRepository.GetAllAsync(cancellationToken);
    }
}
