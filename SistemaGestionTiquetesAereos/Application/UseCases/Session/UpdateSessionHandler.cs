using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class UpdateSessionHandler : IRequestHandler<UpdateSessionCommand>
{
    private readonly ISession _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSessionHandler(ISession sessionRepository, IUnitOfWork unitOfWork)
    {
        _sessionRepository = sessionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _sessionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Session), request.Id);

        if (await _sessionRepository.ExistsByTokenAsync(request.Token, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Session with Token '" + request.Token + "' already exists.");
        }
        entity.Update(request.UserId, request.Token, request.ExpiresAt, request.RevokedAt, request.IsActive);

        _sessionRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
