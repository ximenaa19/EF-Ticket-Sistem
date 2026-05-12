using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class UpdateCabinConfigurationHandler : IRequestHandler<UpdateCabinConfigurationCommand>
{
    private readonly ICabinConfiguration _cabinConfigurationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCabinConfigurationHandler(ICabinConfiguration cabinConfigurationRepository, IUnitOfWork unitOfWork)
    {
        _cabinConfigurationRepository = cabinConfigurationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCabinConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cabinConfigurationRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CabinConfiguration), request.Id);

        entity.Update(request.AircraftId, request.CabinTypeId, request.SeatCount, request.IsActive);

        _cabinConfigurationRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
