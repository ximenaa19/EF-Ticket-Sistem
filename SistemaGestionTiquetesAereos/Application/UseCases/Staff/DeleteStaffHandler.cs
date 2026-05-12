using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class DeleteStaffHandler : IRequestHandler<DeleteStaffCommand>
{
    private readonly IStaff _staffRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStaffHandler(IStaff staffRepository, IUnitOfWork unitOfWork)
    {
        _staffRepository = staffRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
    {
        var entity = await _staffRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Staff), request.Id);

        _staffRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
