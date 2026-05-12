using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed record GetPersonEmailByIdQuery(Guid Id) : IRequest<Domain.Entities.PersonEmail>;
