using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

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
