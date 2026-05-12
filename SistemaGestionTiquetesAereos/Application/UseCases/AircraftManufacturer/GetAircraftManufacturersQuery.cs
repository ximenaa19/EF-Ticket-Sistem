using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed record GetAircraftManufacturersQuery : IRequest<IReadOnlyList<Domain.Entities.AircraftManufacturer>>;
