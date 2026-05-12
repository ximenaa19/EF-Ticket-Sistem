using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed record DeleteCountryCommand(Guid Id) : IRequest;
