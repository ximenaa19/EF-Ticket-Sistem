using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed record UpdateAirportAirlineCommand(Guid Id, Guid AirportId,
    Guid AirlineId, bool IsActive) : IRequest;
