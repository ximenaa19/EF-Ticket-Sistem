using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class DeleteSeasonHandler : IRequestHandler<DeleteSeasonCommand>
{
    private readonly ISeason _seasonRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSeasonHandler(ISeason seasonRepository, IUnitOfWork unitOfWork)
    {
        _seasonRepository = seasonRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteSeasonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _seasonRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Season), request.Id);

        _seasonRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
