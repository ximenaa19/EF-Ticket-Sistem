using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CheckIn;

public sealed class DeleteCheckInHandler : IRequestHandler<DeleteCheckInCommand>
{
    private readonly ICheckIn _checkInRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCheckInHandler(ICheckIn checkInRepository, IUnitOfWork unitOfWork)
    {
        _checkInRepository = checkInRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCheckInCommand request, CancellationToken cancellationToken)
    {
        var entity = await _checkInRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CheckIn), request.Id);

        _checkInRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
