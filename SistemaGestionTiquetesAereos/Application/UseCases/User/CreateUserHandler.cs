using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUser _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUser userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByUserNameAsync(request.UserName, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("User with UserName '" + request.UserName + "' already exists.");
        }
        var entity = new Domain.Entities.User(request.PersonId, request.RoleId, request.UserName, request.PasswordHash);

        await _userRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
