using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed record DeleteAddressCommand(Guid Id) : IRequest;
