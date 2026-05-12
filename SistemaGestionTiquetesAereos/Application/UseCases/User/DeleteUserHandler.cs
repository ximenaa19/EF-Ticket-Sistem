using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUser _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUser userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.User), request.Id);

        _userRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
