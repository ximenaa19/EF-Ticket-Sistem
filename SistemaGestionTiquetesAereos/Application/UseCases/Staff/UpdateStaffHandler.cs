using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class UpdateStaffHandler : IRequestHandler<UpdateStaffCommand>
{
    private readonly IStaff _staffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStaffHandler(IStaff staffRepository, IUnitOfWork unitOfWork)
    {
        _staffRepository = staffRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        var entity = await _staffRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Staff), request.Id);

        if (await _staffRepository.ExistsByEmployeeCodeAsync(request.EmployeeCode, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Staff with EmployeeCode '" + request.EmployeeCode + "' already exists.");
        }
        entity.Update(request.PersonId, request.StaffPositionId, request.EmployeeCode, request.IsActive);

        _staffRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
