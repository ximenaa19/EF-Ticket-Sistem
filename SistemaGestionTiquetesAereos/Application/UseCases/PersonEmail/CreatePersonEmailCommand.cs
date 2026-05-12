using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed record CreatePersonEmailCommand(Guid PersonId,
    Guid EmailDomainId,
    string LocalPart,
    bool IsPrimary) : IRequest<Guid>;
