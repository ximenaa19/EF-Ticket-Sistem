using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed record UpdateSeatLocationTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
