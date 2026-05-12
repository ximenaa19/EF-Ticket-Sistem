using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class CreateStaffHandler : IRequestHandler<CreateStaffCommand, Guid>
{
    private readonly IStaff _staffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStaffHandler(IStaff staffRepository, IUnitOfWork unitOfWork)
    {
        _staffRepository = staffRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        if (await _staffRepository.ExistsByEmployeeCodeAsync(request.EmployeeCode, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Staff with EmployeeCode '" + request.EmployeeCode + "' already exists.");
        }
        var entity = new Domain.Entities.Staff(request.PersonId, request.StaffPositionId, request.EmployeeCode);

        await _staffRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
