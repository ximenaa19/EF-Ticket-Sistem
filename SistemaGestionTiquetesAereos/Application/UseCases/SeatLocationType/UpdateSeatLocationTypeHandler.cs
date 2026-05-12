using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class UpdateSeatLocationTypeHandler : IRequestHandler<UpdateSeatLocationTypeCommand>
{
    private readonly ISeatLocationType _seatLocationTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSeatLocationTypeHandler(ISeatLocationType seatLocationTypeRepository, IUnitOfWork unitOfWork)
    {
        _seatLocationTypeRepository = seatLocationTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSeatLocationTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _seatLocationTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.SeatLocationType), request.Id);

        if (await _seatLocationTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("SeatLocationType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _seatLocationTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
