using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class DeleteFlightAssignmentHandler : IRequestHandler<DeleteFlightAssignmentCommand>
{
    private readonly IFlightAssignment _flightAssignmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlightAssignmentHandler(IFlightAssignment flightAssignmentRepository, IUnitOfWork unitOfWork)
    {
        _flightAssignmentRepository = flightAssignmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFlightAssignmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightAssignmentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightAssignment), request.Id);

        _flightAssignmentRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
