using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class CreatePersonEmailValidator : AbstractValidator<CreatePersonEmailCommand>
{
    public CreatePersonEmailValidator()
    {
        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.EmailDomainId)
            .NotEmpty();

        RuleFor(command => command.LocalPart)
            .NotEmpty()
            .MaximumLength(100);
    }
}
