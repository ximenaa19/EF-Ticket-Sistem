using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class GetCabinConfigurationsHandler : IRequestHandler<GetCabinConfigurationsQuery, IReadOnlyList<Domain.Entities.CabinConfiguration>>
{
    private readonly ICabinConfiguration _cabinConfigurationRepository;

    public GetCabinConfigurationsHandler(ICabinConfiguration cabinConfigurationRepository)
    {
        _cabinConfigurationRepository = cabinConfigurationRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.CabinConfiguration>> Handle(GetCabinConfigurationsQuery request, CancellationToken cancellationToken)
    {
        return _cabinConfigurationRepository.GetAllAsync(cancellationToken);
    }
}
