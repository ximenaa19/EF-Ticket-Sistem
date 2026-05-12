using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed record DeletePersonCommand(Guid Id) : IRequest;
