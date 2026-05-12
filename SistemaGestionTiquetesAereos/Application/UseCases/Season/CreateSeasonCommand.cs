using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed record CreateSeasonCommand(string Name) : IRequest<Guid>;
