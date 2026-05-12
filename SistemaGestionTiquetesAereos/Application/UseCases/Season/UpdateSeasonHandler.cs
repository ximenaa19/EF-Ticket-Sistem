using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class UpdateSeasonHandler : IRequestHandler<UpdateSeasonCommand>
{
    private readonly ISeason _seasonRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSeasonHandler(ISeason seasonRepository, IUnitOfWork unitOfWork)
    {
        _seasonRepository = seasonRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _seasonRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Season), request.Id);

        if (await _seasonRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Season with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _seasonRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
