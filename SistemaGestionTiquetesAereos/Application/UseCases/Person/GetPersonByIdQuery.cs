using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed record GetPersonByIdQuery(Guid Id) : IRequest<Domain.Entities.Person>;
