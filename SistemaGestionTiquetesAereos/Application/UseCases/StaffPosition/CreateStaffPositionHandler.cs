using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class CreateStaffPositionHandler : IRequestHandler<CreateStaffPositionCommand, Guid>
{
    private readonly IStaffPosition _staffPositionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStaffPositionHandler(IStaffPosition staffPositionRepository, IUnitOfWork unitOfWork)
    {
        _staffPositionRepository = staffPositionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateStaffPositionCommand request, CancellationToken cancellationToken)
    {
        if (await _staffPositionRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("StaffPosition with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.StaffPosition(request.Name);

        await _staffPositionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
