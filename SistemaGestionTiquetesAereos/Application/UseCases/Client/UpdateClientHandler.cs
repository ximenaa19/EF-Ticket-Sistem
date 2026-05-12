using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class UpdateClientHandler : IRequestHandler<UpdateClientCommand>
{
    private readonly IClient _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientHandler(IClient clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = await _clientRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Client), request.Id);

        entity.Update(request.PersonId, request.IsActive);

        _clientRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
