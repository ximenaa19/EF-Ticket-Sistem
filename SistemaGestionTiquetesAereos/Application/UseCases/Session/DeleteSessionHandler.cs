using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class DeleteSessionHandler : IRequestHandler<DeleteSessionCommand>
{
    private readonly ISession _sessionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSessionHandler(ISession sessionRepository, IUnitOfWork unitOfWork)
    {
        _sessionRepository = sessionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _sessionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Session), request.Id);

        _sessionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
