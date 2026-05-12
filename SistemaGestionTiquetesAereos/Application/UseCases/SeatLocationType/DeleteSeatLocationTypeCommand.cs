using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed record DeleteSeatLocationTypeCommand(Guid Id) : IRequest;
