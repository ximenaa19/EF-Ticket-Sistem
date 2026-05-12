using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed record CreateSeatLocationTypeCommand(string Name) : IRequest<Guid>;
