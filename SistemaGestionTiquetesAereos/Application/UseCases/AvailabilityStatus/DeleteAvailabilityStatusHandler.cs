using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class DeleteAvailabilityStatusHandler : IRequestHandler<DeleteAvailabilityStatusCommand>
{
    private readonly IAvailabilityStatus _availabilityStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAvailabilityStatusHandler(IAvailabilityStatus availabilityStatusRepository, IUnitOfWork unitOfWork)
    {
        _availabilityStatusRepository = availabilityStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAvailabilityStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _availabilityStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AvailabilityStatus), request.Id);

        _availabilityStatusRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
