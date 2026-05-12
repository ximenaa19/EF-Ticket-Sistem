using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed class GetRegionsHandler : IRequestHandler<GetRegionsQuery, IReadOnlyList<Domain.Entities.Region>>
{
    private readonly IRegion _regionRepository;

    public GetRegionsHandler(IRegion regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Region>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
    {
        return _regionRepository.GetAllAsync(cancellationToken);
    }
}
