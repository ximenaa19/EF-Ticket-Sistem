using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.RoleId)
            .NotEmpty();

        RuleFor(command => command.UserName)
            .NotEmpty()
            .MaximumLength(80);

        RuleFor(command => command.PasswordHash)
            .NotEmpty()
            .MaximumLength(250);
    }
}
