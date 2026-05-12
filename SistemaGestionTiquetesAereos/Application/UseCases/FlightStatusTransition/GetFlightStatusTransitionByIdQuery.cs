using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed record GetFlightStatusTransitionByIdQuery(Guid Id) : IRequest<Domain.Entities.FlightStatusTransition>;
