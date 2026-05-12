using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class DeleteCabinConfigurationHandler : IRequestHandler<DeleteCabinConfigurationCommand>
{
    private readonly ICabinConfiguration _cabinConfigurationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCabinConfigurationHandler(ICabinConfiguration cabinConfigurationRepository, IUnitOfWork unitOfWork)
    {
        _cabinConfigurationRepository = cabinConfigurationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCabinConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cabinConfigurationRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CabinConfiguration), request.Id);

        _cabinConfigurationRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
