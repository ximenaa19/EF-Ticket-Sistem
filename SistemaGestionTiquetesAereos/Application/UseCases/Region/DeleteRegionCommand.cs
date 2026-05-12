using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed record DeleteRegionCommand(Guid Id) : IRequest;
