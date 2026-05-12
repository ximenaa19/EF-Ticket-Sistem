using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed record GetCountryByIdQuery(Guid Id) : IRequest<Domain.Entities.Country>;
