using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed record CreateAircraftManufacturerCommand(string Name) : IRequest<Guid>;
