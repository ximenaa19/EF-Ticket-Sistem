using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed record CreateCabinTypeCommand(string Name) : IRequest<Guid>;
