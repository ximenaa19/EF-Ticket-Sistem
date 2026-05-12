using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class CreateAvailabilityStatusHandler : IRequestHandler<CreateAvailabilityStatusCommand, Guid>
{
    private readonly IAvailabilityStatus _availabilityStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAvailabilityStatusHandler(IAvailabilityStatus availabilityStatusRepository, IUnitOfWork unitOfWork)
    {
        _availabilityStatusRepository = availabilityStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAvailabilityStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _availabilityStatusRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("AvailabilityStatus with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.AvailabilityStatus(request.Name);

        await _availabilityStatusRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
