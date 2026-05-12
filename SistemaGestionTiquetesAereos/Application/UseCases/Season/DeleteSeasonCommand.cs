using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed record DeleteSeasonCommand(Guid Id) : IRequest;
