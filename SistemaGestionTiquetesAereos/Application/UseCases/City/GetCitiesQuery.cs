using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed record GetCitiesQuery : IRequest<IReadOnlyList<Domain.Entities.City>>;
