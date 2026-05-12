using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class UpdateStaffPositionHandler : IRequestHandler<UpdateStaffPositionCommand>
{
    private readonly IStaffPosition _staffPositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStaffPositionHandler(IStaffPosition staffPositionRepository, IUnitOfWork unitOfWork)
    {
        _staffPositionRepository = staffPositionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateStaffPositionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _staffPositionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.StaffPosition), request.Id);

        if (await _staffPositionRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("StaffPosition with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _staffPositionRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
