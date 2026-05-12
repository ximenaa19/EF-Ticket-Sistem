using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class CreateCheckInStatusHandler : IRequestHandler<CreateCheckInStatusCommand, Guid>
{
    private readonly ICheckInStatus _checkInStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCheckInStatusHandler(ICheckInStatus checkInStatusRepository, IUnitOfWork unitOfWork)
    {
        _checkInStatusRepository = checkInStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCheckInStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _checkInStatusRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("CheckInStatus with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.CheckInStatus(request.Name);

        await _checkInStatusRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
