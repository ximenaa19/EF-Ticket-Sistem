using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

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
