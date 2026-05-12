using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed record CreatePassengerTypeCommand(string Name) : IRequest<Guid>;
