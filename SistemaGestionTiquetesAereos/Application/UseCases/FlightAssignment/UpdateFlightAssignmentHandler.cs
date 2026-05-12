using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class UpdateFlightAssignmentHandler : IRequestHandler<UpdateFlightAssignmentCommand>
{
    private readonly IFlightAssignment _flightAssignmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlightAssignmentHandler(IFlightAssignment flightAssignmentRepository, IUnitOfWork unitOfWork)
    {
        _flightAssignmentRepository = flightAssignmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFlightAssignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightAssignmentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightAssignment), request.Id);

        entity.Update(request.FlightId, request.StaffId, request.FlightRoleId, request.IsActive);

        _flightAssignmentRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
