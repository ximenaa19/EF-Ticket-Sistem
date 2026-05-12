using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed record GetAddressesQuery : IRequest<IReadOnlyList<Domain.Entities.Address>>;
