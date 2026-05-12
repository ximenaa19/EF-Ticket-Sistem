using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class CreateSeatLocationTypeHandler : IRequestHandler<CreateSeatLocationTypeCommand, Guid>
{
    private readonly ISeatLocationType _seatLocationTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSeatLocationTypeHandler(ISeatLocationType seatLocationTypeRepository, IUnitOfWork unitOfWork)
    {
        _seatLocationTypeRepository = seatLocationTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateSeatLocationTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _seatLocationTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("SeatLocationType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.SeatLocationType(request.Name);

        await _seatLocationTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
