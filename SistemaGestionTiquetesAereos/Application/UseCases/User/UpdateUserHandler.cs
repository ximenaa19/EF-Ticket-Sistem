using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUser _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUser userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _userRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.User), request.Id);

        if (await _userRepository.ExistsByUserNameAsync(request.UserName, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("User with UserName '" + request.UserName + "' already exists.");
        }
        entity.Update(request.PersonId, request.RoleId, request.UserName, request.PasswordHash, request.IsActive);

        _userRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
