using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed record DeleteFareCommand(Guid Id) : IRequest;
