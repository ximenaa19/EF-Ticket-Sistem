using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class UpdateCheckInStatusHandler : IRequestHandler<UpdateCheckInStatusCommand>
{
    private readonly ICheckInStatus _checkInStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCheckInStatusHandler(ICheckInStatus checkInStatusRepository, IUnitOfWork unitOfWork)
    {
        _checkInStatusRepository = checkInStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCheckInStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _checkInStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CheckInStatus), request.Id);

        if (await _checkInStatusRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("CheckInStatus with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _checkInStatusRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
