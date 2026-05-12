using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class CreateFlightAssignmentHandler : IRequestHandler<CreateFlightAssignmentCommand, Guid>
{
    private readonly IFlightAssignment _flightAssignmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightAssignmentHandler(IFlightAssignment flightAssignmentRepository, IUnitOfWork unitOfWork)
    {
        _flightAssignmentRepository = flightAssignmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightAssignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.FlightAssignment(request.FlightId, request.StaffId, request.FlightRoleId);

        await _flightAssignmentRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
