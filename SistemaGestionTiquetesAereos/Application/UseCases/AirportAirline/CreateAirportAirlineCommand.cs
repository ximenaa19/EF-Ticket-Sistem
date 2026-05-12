using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed record CreateAirportAirlineCommand(Guid AirportId,
    Guid AirlineId) : IRequest<Guid>;
