using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed class GetRegionByIdHandler : IRequestHandler<GetRegionByIdQuery, Domain.Entities.Region>
{
    private readonly IRegion _regionRepository;

    public GetRegionByIdHandler(IRegion regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public async Task<Domain.Entities.Region> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _regionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Region), request.Id);
    }
}
