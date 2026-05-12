using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class CreateCheckInHandler : IRequestHandler<CreateCheckInCommand, Guid>
{
    private readonly ICheckIn _checkInRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCheckInHandler(ICheckIn checkInRepository, IUnitOfWork unitOfWork)
    {
        _checkInRepository = checkInRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCheckInCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.CheckIn(request.TicketId, request.CheckInStatusId, request.SeatId, request.CheckedInAt);

        await _checkInRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
