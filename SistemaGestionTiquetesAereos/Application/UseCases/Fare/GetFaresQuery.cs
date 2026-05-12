using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed record GetFaresQuery : IRequest<IReadOnlyList<Domain.Entities.Fare>>;
