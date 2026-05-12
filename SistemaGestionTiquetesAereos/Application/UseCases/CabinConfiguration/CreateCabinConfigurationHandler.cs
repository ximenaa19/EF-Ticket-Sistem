using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class CreateCabinConfigurationHandler : IRequestHandler<CreateCabinConfigurationCommand, Guid>
{
    private readonly ICabinConfiguration _cabinConfigurationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCabinConfigurationHandler(ICabinConfiguration cabinConfigurationRepository, IUnitOfWork unitOfWork)
    {
        _cabinConfigurationRepository = cabinConfigurationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCabinConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.CabinConfiguration(request.AircraftId, request.CabinTypeId, request.SeatCount);

        await _cabinConfigurationRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
