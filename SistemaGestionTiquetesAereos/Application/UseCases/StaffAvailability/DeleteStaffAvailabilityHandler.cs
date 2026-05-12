using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class DeleteStaffAvailabilityHandler : IRequestHandler<DeleteStaffAvailabilityCommand>
{
    private readonly IStaffAvailability _staffAvailabilityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStaffAvailabilityHandler(IStaffAvailability staffAvailabilityRepository, IUnitOfWork unitOfWork)
    {
        _staffAvailabilityRepository = staffAvailabilityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteStaffAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _staffAvailabilityRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.StaffAvailability), request.Id);

        _staffAvailabilityRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
