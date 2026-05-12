using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed record GetFareByIdQuery(Guid Id) : IRequest<Domain.Entities.Fare>;
