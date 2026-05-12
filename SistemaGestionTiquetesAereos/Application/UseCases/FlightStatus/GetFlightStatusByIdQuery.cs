using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed record GetFlightStatusByIdQuery(Guid Id) : IRequest<Domain.Entities.FlightStatus>;
