using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Session;

public sealed class UpdateSessionValidator : AbstractValidator<UpdateSessionCommand>
{
    public UpdateSessionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.UserId)
            .NotEmpty();

        RuleFor(command => command.Token)
            .NotEmpty()
            .MaximumLength(250);
    }
}
