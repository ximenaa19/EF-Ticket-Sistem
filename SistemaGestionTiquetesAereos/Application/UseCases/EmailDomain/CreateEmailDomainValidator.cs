using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class CreateEmailDomainValidator : AbstractValidator<CreateEmailDomainCommand>
{
    public CreateEmailDomainValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);
    }
}
