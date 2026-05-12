using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed record UpdateCabinTypeCommand(Guid Id, string Name, bool IsActive) : IRequest;
