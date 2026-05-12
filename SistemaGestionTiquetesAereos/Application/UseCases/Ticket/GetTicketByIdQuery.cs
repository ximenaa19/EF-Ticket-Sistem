using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed record GetTicketByIdQuery(Guid Id) : IRequest<Domain.Entities.Ticket>;
