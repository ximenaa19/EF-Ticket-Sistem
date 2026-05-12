using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed record GetPassengerByIdQuery(Guid Id) : IRequest<Domain.Entities.Passenger>;
