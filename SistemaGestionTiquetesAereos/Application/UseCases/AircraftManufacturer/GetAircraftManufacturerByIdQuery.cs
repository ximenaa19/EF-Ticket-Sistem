using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed record GetAircraftManufacturerByIdQuery(Guid Id) : IRequest<Domain.Entities.AircraftManufacturer>;
