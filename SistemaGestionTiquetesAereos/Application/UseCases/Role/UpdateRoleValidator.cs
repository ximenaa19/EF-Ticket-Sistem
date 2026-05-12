using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.Code)
            .NotEmpty()
            .MaximumLength(80);
    }
}
