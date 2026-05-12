using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed record DeleteCabinConfigurationCommand(Guid Id) : IRequest;
