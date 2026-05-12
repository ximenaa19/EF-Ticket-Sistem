using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed record GetFlightSeatByIdQuery(Guid Id) : IRequest<Domain.Entities.FlightSeat>;
