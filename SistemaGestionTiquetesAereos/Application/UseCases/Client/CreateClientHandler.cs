using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class CreateClientHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly IClient _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClientHandler(IClient clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Client(request.PersonId);

        await _clientRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
