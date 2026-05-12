using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonValidator()
    {
        RuleFor(command => command.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(command => command.DocumentTypeId)
            .NotEmpty();

        RuleFor(command => command.DocumentNumber)
            .NotEmpty()
            .MaximumLength(40);
    }
}
