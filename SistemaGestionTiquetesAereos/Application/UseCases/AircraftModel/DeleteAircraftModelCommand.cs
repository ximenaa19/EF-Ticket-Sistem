using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed record DeleteAircraftModelCommand(Guid Id) : IRequest;
