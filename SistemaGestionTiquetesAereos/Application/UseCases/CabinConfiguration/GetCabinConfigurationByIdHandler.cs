using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class GetCabinConfigurationByIdHandler : IRequestHandler<GetCabinConfigurationByIdQuery, Domain.Entities.CabinConfiguration>
{
    private readonly ICabinConfiguration _cabinConfigurationRepository;

    public GetCabinConfigurationByIdHandler(ICabinConfiguration cabinConfigurationRepository)
    {
        _cabinConfigurationRepository = cabinConfigurationRepository;
    }

    public async Task<Domain.Entities.CabinConfiguration> Handle(GetCabinConfigurationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _cabinConfigurationRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CabinConfiguration), request.Id);
    }
}
