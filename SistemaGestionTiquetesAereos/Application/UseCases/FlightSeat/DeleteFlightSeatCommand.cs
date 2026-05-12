using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed record DeleteFlightSeatCommand(Guid Id) : IRequest;
