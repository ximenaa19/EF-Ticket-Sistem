using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed record DeleteAircraftCommand(Guid Id) : IRequest;
