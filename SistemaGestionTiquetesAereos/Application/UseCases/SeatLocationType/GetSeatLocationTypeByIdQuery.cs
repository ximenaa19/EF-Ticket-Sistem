using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed record GetSeatLocationTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.SeatLocationType>;
