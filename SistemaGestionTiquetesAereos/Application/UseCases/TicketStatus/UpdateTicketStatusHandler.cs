using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class UpdateTicketStatusHandler : IRequestHandler<UpdateTicketStatusCommand>
{
    private readonly ITicketStatus _ticketStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketStatusHandler(ITicketStatus ticketStatusRepository, IUnitOfWork unitOfWork)
    {
        _ticketStatusRepository = ticketStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateTicketStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ticketStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.TicketStatus), request.Id);

        if (await _ticketStatusRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("TicketStatus with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _ticketStatusRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
