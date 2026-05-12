using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class UpdateStaffAvailabilityHandler : IRequestHandler<UpdateStaffAvailabilityCommand>
{
    private readonly IStaffAvailability _staffAvailabilityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStaffAvailabilityHandler(IStaffAvailability staffAvailabilityRepository, IUnitOfWork unitOfWork)
    {
        _staffAvailabilityRepository = staffAvailabilityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateStaffAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _staffAvailabilityRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.StaffAvailability), request.Id);

        entity.Update(request.StaffId, request.AvailabilityStatusId, request.AvailableFrom, request.AvailableTo, request.IsActive);

        _staffAvailabilityRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
