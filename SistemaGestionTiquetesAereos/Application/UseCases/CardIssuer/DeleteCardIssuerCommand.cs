using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed record DeleteCardIssuerCommand(Guid Id) : IRequest;
