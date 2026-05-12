using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class DeleteCabinTypeHandler : IRequestHandler<DeleteCabinTypeCommand>
{
    private readonly ICabinType _cabinTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCabinTypeHandler(ICabinType cabinTypeRepository, IUnitOfWork unitOfWork)
    {
        _cabinTypeRepository = cabinTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCabinTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cabinTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CabinType), request.Id);

        _cabinTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
