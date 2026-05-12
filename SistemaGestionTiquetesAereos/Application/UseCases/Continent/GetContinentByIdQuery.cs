using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed record GetContinentByIdQuery(Guid Id) : IRequest<Domain.Entities.Continent>;
