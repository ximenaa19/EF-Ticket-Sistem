using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.TicketStatus;

public sealed class CreateTicketStatusHandler : IRequestHandler<CreateTicketStatusCommand, Guid>
{
    private readonly ITicketStatus _ticketStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketStatusHandler(ITicketStatus ticketStatusRepository, IUnitOfWork unitOfWork)
    {
        _ticketStatusRepository = ticketStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTicketStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _ticketStatusRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("TicketStatus with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.TicketStatus(request.Name);

        await _ticketStatusRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
