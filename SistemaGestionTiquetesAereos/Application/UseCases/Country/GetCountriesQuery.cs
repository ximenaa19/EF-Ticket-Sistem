using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed record GetCountriesQuery : IRequest<IReadOnlyList<Domain.Entities.Country>>;
