using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class UpdateAddressValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.RoadTypeId)
            .NotEmpty();

        RuleFor(command => command.CityId)
            .NotEmpty();

        RuleFor(command => command.Street)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(command => command.Number)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(command => command.AdditionalInfo)
            .MaximumLength(250);
    }
}
