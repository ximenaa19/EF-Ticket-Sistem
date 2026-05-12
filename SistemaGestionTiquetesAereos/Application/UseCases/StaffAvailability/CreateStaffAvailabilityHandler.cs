using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class CreateStaffAvailabilityHandler : IRequestHandler<CreateStaffAvailabilityCommand, Guid>
{
    private readonly IStaffAvailability _staffAvailabilityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStaffAvailabilityHandler(IStaffAvailability staffAvailabilityRepository, IUnitOfWork unitOfWork)
    {
        _staffAvailabilityRepository = staffAvailabilityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateStaffAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.StaffAvailability(request.StaffId, request.AvailabilityStatusId, request.AvailableFrom, request.AvailableTo);

        await _staffAvailabilityRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
