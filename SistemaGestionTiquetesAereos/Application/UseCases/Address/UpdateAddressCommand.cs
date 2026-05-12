using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed record UpdateAddressCommand(Guid Id, Guid RoadTypeId,
    Guid CityId,
    string Street,
    string Number,
    string? AdditionalInfo, bool IsActive) : IRequest;
