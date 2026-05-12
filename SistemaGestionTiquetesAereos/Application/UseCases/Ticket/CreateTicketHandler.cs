using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed class CreateTicketHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly ITicket _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketHandler(ITicket ticketRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        if (await _ticketRepository.ExistsByTicketNumberAsync(request.TicketNumber, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Ticket with TicketNumber '" + request.TicketNumber + "' already exists.");
        }
        var entity = new Domain.Entities.Ticket(request.ReservationId, request.PassengerId, request.FlightId, request.TicketStatusId, request.TicketNumber, request.FareAmount, request.Currency);

        await _ticketRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
