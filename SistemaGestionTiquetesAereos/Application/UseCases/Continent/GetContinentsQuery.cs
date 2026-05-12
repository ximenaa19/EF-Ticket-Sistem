using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed record GetContinentsQuery : IRequest<IReadOnlyList<Domain.Entities.Continent>>;
