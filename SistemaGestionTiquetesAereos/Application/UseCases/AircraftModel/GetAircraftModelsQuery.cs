using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed record GetAircraftModelsQuery : IRequest<IReadOnlyList<Domain.Entities.AircraftModel>>;
