using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed record CreateAddressCommand(Guid RoadTypeId,
    Guid CityId,
    string Street,
    string Number,
    string? AdditionalInfo) : IRequest<Guid>;
