using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed class DeleteFareHandler : IRequestHandler<DeleteFareCommand>
{
    private readonly IFare _fareRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFareHandler(IFare fareRepository, IUnitOfWork unitOfWork)
    {
        _fareRepository = fareRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteFareCommand request, CancellationToken cancellationToken)
    {
        var entity = await _fareRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Fare), request.Id);

        _fareRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
