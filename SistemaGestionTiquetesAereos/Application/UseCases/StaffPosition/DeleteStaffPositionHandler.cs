using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class DeleteStaffPositionHandler : IRequestHandler<DeleteStaffPositionCommand>
{
    private readonly IStaffPosition _staffPositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStaffPositionHandler(IStaffPosition staffPositionRepository, IUnitOfWork unitOfWork)
    {
        _staffPositionRepository = staffPositionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteStaffPositionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _staffPositionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.StaffPosition), request.Id);

        _staffPositionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
