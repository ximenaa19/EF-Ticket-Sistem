using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed record UpdatePersonEmailCommand(Guid Id, Guid PersonId,
    Guid EmailDomainId,
    string LocalPart,
    bool IsPrimary, bool IsActive) : IRequest;
