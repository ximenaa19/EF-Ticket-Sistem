using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand>
{
    private readonly ITicket _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTicketHandler(ITicket ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ticketRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Ticket), request.Id);

        _ticketRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
