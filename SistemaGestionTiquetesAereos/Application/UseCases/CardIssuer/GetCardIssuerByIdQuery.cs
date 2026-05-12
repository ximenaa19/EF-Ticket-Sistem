using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed record GetCardIssuerByIdQuery(Guid Id) : IRequest<Domain.Entities.CardIssuer>;
