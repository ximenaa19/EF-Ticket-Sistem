using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed record UpdateCabinConfigurationCommand(Guid Id, Guid AircraftId,
    Guid CabinTypeId,
    int SeatCount, bool IsActive) : IRequest;
