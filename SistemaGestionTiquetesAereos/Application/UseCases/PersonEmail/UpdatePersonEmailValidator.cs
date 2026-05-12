using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class UpdatePersonEmailValidator : AbstractValidator<UpdatePersonEmailCommand>
{
    public UpdatePersonEmailValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.EmailDomainId)
            .NotEmpty();

        RuleFor(command => command.LocalPart)
            .NotEmpty()
            .MaximumLength(100);
    }
}
