using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed record DeletePersonEmailCommand(Guid Id) : IRequest;
