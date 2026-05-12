using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed record GetAddressByIdQuery(Guid Id) : IRequest<Domain.Entities.Address>;
