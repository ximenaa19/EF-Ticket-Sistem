using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class DeleteSeatLocationTypeHandler : IRequestHandler<DeleteSeatLocationTypeCommand>
{
    private readonly ISeatLocationType _seatLocationTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSeatLocationTypeHandler(ISeatLocationType seatLocationTypeRepository, IUnitOfWork unitOfWork)
    {
        _seatLocationTypeRepository = seatLocationTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSeatLocationTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _seatLocationTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.SeatLocationType), request.Id);

        _seatLocationTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
