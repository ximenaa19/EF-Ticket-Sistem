using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed record UpdatePassengerTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
