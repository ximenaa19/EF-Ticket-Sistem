using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class CreateSessionHandler : IRequestHandler<CreateSessionCommand, Guid>
{
    private readonly ISession _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSessionHandler(ISession sessionRepository, IUnitOfWork unitOfWork)
    {
        _sessionRepository = sessionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        if (await _sessionRepository.ExistsByTokenAsync(request.Token, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Session with Token '" + request.Token + "' already exists.");
        }
        var entity = new Domain.Entities.Session(request.UserId, request.Token, request.ExpiresAt, request.RevokedAt);

        await _sessionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
