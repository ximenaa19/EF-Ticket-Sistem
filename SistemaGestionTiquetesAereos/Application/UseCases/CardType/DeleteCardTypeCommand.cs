using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed record DeleteCardTypeCommand(Guid Id) : IRequest;
