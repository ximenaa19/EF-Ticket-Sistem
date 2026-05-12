using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class GetFlightRoleByIdHandler : IRequestHandler<GetFlightRoleByIdQuery, Domain.Entities.FlightRole>
{
    private readonly IFlightRole _flightRoleRepository;

    public GetFlightRoleByIdHandler(IFlightRole flightRoleRepository)
    {
        _flightRoleRepository = flightRoleRepository;
    }

    public async Task<Domain.Entities.FlightRole> Handle(GetFlightRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _flightRoleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightRole), request.Id);
    }
}
