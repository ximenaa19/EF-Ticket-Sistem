using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.DocumentType;

public sealed class CreateDocumentTypeValidator : AbstractValidator<CreateDocumentTypeCommand>
{
    public CreateDocumentTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
