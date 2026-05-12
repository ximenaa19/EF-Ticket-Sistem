using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed record UpdateCardIssuerCommand(Guid Id, string Name, bool IsActive) : IRequest;
