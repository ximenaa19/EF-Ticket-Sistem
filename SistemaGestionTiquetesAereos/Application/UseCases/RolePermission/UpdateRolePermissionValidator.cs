using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class UpdateRolePermissionValidator : AbstractValidator<UpdateRolePermissionCommand>
{
    public UpdateRolePermissionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.RoleId)
            .NotEmpty();

        RuleFor(command => command.PermissionId)
            .NotEmpty();
    }
}
