using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Client;

public sealed class DeleteClientHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IClient _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClientHandler(IClient clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var entity = await _clientRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Client), request.Id);

        _clientRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
