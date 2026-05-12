using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed record UpdateCardTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
