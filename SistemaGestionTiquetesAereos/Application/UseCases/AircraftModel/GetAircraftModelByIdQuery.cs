using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed record GetAircraftModelByIdQuery(Guid Id) : IRequest<Domain.Entities.AircraftModel>;
