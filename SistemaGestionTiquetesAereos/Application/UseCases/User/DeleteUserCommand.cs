using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed record DeleteUserCommand(Guid Id) : IRequest;
