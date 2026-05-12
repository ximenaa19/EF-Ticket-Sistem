using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed record GetSeasonsQuery : IRequest<IReadOnlyList<Domain.Entities.Season>>;
