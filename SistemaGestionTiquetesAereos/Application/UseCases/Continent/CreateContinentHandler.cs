using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class CreateContinentHandler : IRequestHandler<CreateContinentCommand, Guid>
{
    private readonly IContinent _continentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateContinentHandler(IContinent continentRepository, IUnitOfWork unitOfWork)
    {
        _continentRepository = continentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateContinentCommand request, CancellationToken cancellationToken)
    {
        if (await _continentRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException($"Continent with name '{request.Name}' already exists.");
        }

        var continent = new Domain.Entities.Continent(request.Name);

        await _continentRepository.AddAsync(continent, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return continent.Id;
    }
}
