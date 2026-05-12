using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed record CreateCardIssuerCommand(string Name) : IRequest<Guid>;
