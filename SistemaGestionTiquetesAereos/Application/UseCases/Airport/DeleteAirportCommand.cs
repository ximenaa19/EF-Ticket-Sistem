using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed record DeleteAirportCommand(Guid Id) : IRequest;
