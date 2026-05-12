using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed record GetAirlinesQuery : IRequest<IReadOnlyList<Domain.Entities.Airline>>;
