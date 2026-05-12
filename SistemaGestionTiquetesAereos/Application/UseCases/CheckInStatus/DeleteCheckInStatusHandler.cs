using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckInStatus;

public sealed class DeleteCheckInStatusHandler : IRequestHandler<DeleteCheckInStatusCommand>
{
    private readonly ICheckInStatus _checkInStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCheckInStatusHandler(ICheckInStatus checkInStatusRepository, IUnitOfWork unitOfWork)
    {
        _checkInStatusRepository = checkInStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCheckInStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _checkInStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CheckInStatus), request.Id);

        _checkInStatusRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
