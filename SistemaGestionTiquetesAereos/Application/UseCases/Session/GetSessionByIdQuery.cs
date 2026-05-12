using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed record GetSessionByIdQuery(Guid Id) : IRequest<Domain.Entities.Session>;
