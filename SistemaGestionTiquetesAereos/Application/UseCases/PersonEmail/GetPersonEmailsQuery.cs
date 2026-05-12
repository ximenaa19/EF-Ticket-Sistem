using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed record GetPersonEmailsQuery : IRequest<IReadOnlyList<Domain.Entities.PersonEmail>>;
