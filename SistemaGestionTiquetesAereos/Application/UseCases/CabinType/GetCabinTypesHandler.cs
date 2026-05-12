using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class GetCabinTypesHandler : IRequestHandler<GetCabinTypesQuery, IReadOnlyList<Domain.Entities.CabinType>>
{
    private readonly ICabinType _cabinTypeRepository;

    public GetCabinTypesHandler(ICabinType cabinTypeRepository)
    {
        _cabinTypeRepository = cabinTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.CabinType>> Handle(GetCabinTypesQuery request, CancellationToken cancellationToken)
    {
        return _cabinTypeRepository.GetAllAsync(cancellationToken);
    }
}
