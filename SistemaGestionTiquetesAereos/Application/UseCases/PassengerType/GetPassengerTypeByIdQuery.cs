using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed record GetPassengerTypeByIdQuery(Guid Id) : IRequest<Domain.Entities.PassengerType>;
