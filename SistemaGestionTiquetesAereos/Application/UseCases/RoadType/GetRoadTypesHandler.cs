using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class GetRoadTypesHandler : IRequestHandler<GetRoadTypesQuery, IReadOnlyList<Domain.Entities.RoadType>>
{
    private readonly IRoadType _roadTypeRepository;

    public GetRoadTypesHandler(IRoadType roadTypeRepository)
    {
        _roadTypeRepository = roadTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.RoadType>> Handle(GetRoadTypesQuery request, CancellationToken cancellationToken)
    {
        return _roadTypeRepository.GetAllAsync(cancellationToken);
    }
}
