using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed record UpdateAircraftManufacturerCommand(Guid Id, string Name, bool IsActive) : IRequest;
