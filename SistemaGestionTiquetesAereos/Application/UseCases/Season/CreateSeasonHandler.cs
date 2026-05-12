using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class CreateSeasonHandler : IRequestHandler<CreateSeasonCommand, Guid>
{
    private readonly ISeason _seasonRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSeasonHandler(ISeason seasonRepository, IUnitOfWork unitOfWork)
    {
        _seasonRepository = seasonRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
    {
        if (await _seasonRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Season with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.Season(request.Name);

        await _seasonRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
