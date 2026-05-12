using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed record CreateCabinConfigurationCommand(Guid AircraftId,
    Guid CabinTypeId,
    int SeatCount) : IRequest<Guid>;
