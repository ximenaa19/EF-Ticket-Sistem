using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class GetUsersHandler : IRequestHandler<GetUsersQuery, IReadOnlyList<Domain.Entities.User>>
{
    private readonly IUser _userRepository;

    public GetUsersHandler(IUser userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return _userRepository.GetAllAsync(cancellationToken);
    }
}
