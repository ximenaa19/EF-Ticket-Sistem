using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed record DeletePassengerCommand(Guid Id) : IRequest;
