using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class UpdatePermissionValidator : AbstractValidator<UpdatePermissionCommand>
{
    public UpdatePermissionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(command => command.Code)
            .NotEmpty()
            .MaximumLength(80);
    }
}
