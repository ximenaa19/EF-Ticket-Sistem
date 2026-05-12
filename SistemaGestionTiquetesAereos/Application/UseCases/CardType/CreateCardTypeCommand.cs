using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed record CreateCardTypeCommand(string Name) : IRequest<Guid>;
