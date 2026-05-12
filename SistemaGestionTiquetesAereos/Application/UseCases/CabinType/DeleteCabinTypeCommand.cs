using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed record DeleteCabinTypeCommand(Guid Id) : IRequest;
