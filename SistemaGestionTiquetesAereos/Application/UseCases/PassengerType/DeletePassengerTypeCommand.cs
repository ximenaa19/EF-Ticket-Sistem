using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed record DeletePassengerTypeCommand(Guid Id) : IRequest;
