using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class GetCabinTypeByIdHandler : IRequestHandler<GetCabinTypeByIdQuery, Domain.Entities.CabinType>
{
    private readonly ICabinType _cabinTypeRepository;

    public GetCabinTypeByIdHandler(ICabinType cabinTypeRepository)
    {
        _cabinTypeRepository = cabinTypeRepository;
    }

    public async Task<Domain.Entities.CabinType> Handle(GetCabinTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _cabinTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CabinType), request.Id);
    }
}
