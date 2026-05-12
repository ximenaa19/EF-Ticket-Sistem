using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed record GetTicketStatusByIdQuery(Guid Id) : IRequest<Domain.Entities.TicketStatus>;
