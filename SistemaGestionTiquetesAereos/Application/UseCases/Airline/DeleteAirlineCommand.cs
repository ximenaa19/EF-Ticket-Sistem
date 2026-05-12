using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed record DeleteAirlineCommand(Guid Id) : IRequest;
