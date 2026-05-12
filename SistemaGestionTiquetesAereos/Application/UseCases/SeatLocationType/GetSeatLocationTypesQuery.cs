using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed record GetSeatLocationTypesQuery : IRequest<IReadOnlyList<Domain.Entities.SeatLocationType>>;
