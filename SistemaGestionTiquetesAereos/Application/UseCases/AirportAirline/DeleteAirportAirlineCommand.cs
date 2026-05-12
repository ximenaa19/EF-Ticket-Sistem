using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed record DeleteAirportAirlineCommand(Guid Id) : IRequest;
