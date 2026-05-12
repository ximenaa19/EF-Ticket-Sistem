using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class UpdateCheckInHandler : IRequestHandler<UpdateCheckInCommand>
{
    private readonly ICheckIn _checkInRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCheckInHandler(ICheckIn checkInRepository, IUnitOfWork unitOfWork)
    {
        _checkInRepository = checkInRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCheckInCommand request, CancellationToken cancellationToken)
    {
        var entity = await _checkInRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CheckIn), request.Id);

        entity.Update(request.TicketId, request.CheckInStatusId, request.SeatId, request.CheckedInAt, request.IsActive);

        _checkInRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
