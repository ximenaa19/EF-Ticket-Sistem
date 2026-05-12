using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed record GetCityByIdQuery(Guid Id) : IRequest<Domain.Entities.City>;
