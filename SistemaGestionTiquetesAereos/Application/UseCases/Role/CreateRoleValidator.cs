using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.Code)
            .NotEmpty()
            .MaximumLength(80);
    }
}
