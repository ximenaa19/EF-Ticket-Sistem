using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed record GetCabinConfigurationByIdQuery(Guid Id) : IRequest<Domain.Entities.CabinConfiguration>;
