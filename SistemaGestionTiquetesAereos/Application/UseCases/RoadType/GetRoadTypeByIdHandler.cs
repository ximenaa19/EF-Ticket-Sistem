using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class GetRoadTypeByIdHandler : IRequestHandler<GetRoadTypeByIdQuery, Domain.Entities.RoadType>
{
    private readonly IRoadType _roadTypeRepository;

    public GetRoadTypeByIdHandler(IRoadType roadTypeRepository)
    {
        _roadTypeRepository = roadTypeRepository;
    }

    public async Task<Domain.Entities.RoadType> Handle(GetRoadTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _roadTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RoadType), request.Id);
    }
}
