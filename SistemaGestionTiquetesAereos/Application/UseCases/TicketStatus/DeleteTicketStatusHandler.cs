using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class DeleteTicketStatusHandler : IRequestHandler<DeleteTicketStatusCommand>
{
    private readonly ITicketStatus _ticketStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketStatusHandler(ITicketStatus ticketStatusRepository, IUnitOfWork unitOfWork)
    {
        _ticketStatusRepository = ticketStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTicketStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ticketStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.TicketStatus), request.Id);

        _ticketStatusRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
