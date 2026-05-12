using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class UpdateDocumentTypeValidator : AbstractValidator<UpdateDocumentTypeCommand>
{
    public UpdateDocumentTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
