using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed record DeleteFlightCommand(Guid Id) : IRequest;
