using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed class DeleteRegionHandler : IRequestHandler<DeleteRegionCommand>
{
    private readonly IRegion _regionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRegionHandler(IRegion regionRepository, IUnitOfWork unitOfWork)
    {
        _regionRepository = regionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _regionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Region), request.Id);

        _regionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
