using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed record DeleteCheckInCommand(Guid Id) : IRequest;
