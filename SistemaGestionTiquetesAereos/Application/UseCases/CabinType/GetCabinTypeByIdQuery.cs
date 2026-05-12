using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed record GetCabinTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.CabinType>;
