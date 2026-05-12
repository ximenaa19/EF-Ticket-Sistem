using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class GetFlightAssignmentByIdHandler : IRequestHandler<GetFlightAssignmentByIdQuery, Domain.Entities.FlightAssignment>
{
    private readonly IFlightAssignment _flightAssignmentRepository;

    public GetFlightAssignmentByIdHandler(IFlightAssignment flightAssignmentRepository)
    {
        _flightAssignmentRepository = flightAssignmentRepository;
    }

    public async Task<Domain.Entities.FlightAssignment> Handle(GetFlightAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _flightAssignmentRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightAssignment), request.Id);
    }
}
