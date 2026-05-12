using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class UpdateAvailabilityStatusHandler : IRequestHandler<UpdateAvailabilityStatusCommand>
{
    private readonly IAvailabilityStatus _availabilityStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAvailabilityStatusHandler(IAvailabilityStatus availabilityStatusRepository, IUnitOfWork unitOfWork)
    {
        _availabilityStatusRepository = availabilityStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAvailabilityStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _availabilityStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AvailabilityStatus), request.Id);

        if (await _availabilityStatusRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("AvailabilityStatus with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _availabilityStatusRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
