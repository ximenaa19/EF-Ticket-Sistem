using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand>
{
    private readonly ITicket _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketHandler(ITicket ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ticketRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Ticket), request.Id);

        if (await _ticketRepository.ExistsByTicketNumberAsync(request.TicketNumber, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Ticket with TicketNumber '" + request.TicketNumber + "' already exists.");
        }
        entity.Update(request.ReservationId, request.PassengerId, request.FlightId, request.TicketStatusId, request.TicketNumber, request.FareAmount, request.Currency, request.IsActive);

        _ticketRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
