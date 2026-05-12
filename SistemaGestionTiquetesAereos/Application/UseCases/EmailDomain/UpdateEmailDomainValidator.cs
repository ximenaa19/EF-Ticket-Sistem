using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.EmailDomain;

public sealed class UpdateEmailDomainValidator : AbstractValidator<UpdateEmailDomainCommand>
{
    public UpdateEmailDomainValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);
    }
}
