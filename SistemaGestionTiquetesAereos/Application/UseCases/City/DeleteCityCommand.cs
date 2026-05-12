using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed record DeleteCityCommand(Guid Id) : IRequest;
