using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class GetFlightAssignmentsHandler : IRequestHandler<GetFlightAssignmentsQuery, IReadOnlyList<Domain.Entities.FlightAssignment>>
{
    private readonly IFlightAssignment _flightAssignmentRepository;

    public GetFlightAssignmentsHandler(IFlightAssignment flightAssignmentRepository)
    {
        _flightAssignmentRepository = flightAssignmentRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.FlightAssignment>> Handle(GetFlightAssignmentsQuery request, CancellationToken cancellationToken)
    {
        return _flightAssignmentRepository.GetAllAsync(cancellationToken);
    }
}
