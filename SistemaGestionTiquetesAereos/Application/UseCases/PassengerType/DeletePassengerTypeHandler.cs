using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class DeletePassengerTypeHandler : IRequestHandler<DeletePassengerTypeCommand>
{
    private readonly IPassengerType _passengerTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePassengerTypeHandler(IPassengerType passengerTypeRepository, IUnitOfWork unitOfWork)
    {
        _passengerTypeRepository = passengerTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePassengerTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _passengerTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PassengerType), request.Id);

        _passengerTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
