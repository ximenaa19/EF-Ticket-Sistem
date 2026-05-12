using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(command => command.Code)
            .NotEmpty()
            .MaximumLength(80);
    }
}
