using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<Domain.Entities.User>;
