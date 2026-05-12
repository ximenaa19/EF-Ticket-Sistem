using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed record GetPeopleQuery : IRequest<IReadOnlyList<Domain.Entities.Person>>;
