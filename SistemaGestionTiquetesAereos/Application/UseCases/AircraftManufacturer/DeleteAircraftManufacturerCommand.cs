using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed record DeleteAircraftManufacturerCommand(Guid Id) : IRequest;
