using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class CreateRolePermissionValidator : AbstractValidator<CreateRolePermissionCommand>
{
    public CreateRolePermissionValidator()
    {
        RuleFor(command => command.RoleId)
            .NotEmpty();

        RuleFor(command => command.PermissionId)
            .NotEmpty();
    }
}
