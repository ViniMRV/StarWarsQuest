using FluentValidation;
using StarWarsQuest.Api.Commands;

namespace StarWarsQuest.Api.Validators;

public class CreatePlanetValidator : AbstractValidator<CreatePlanetCommand>
{
    public CreatePlanetValidator() 
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name must not be empty")
            .MaximumLength(40).WithMessage("Max name length is 40 characters");

        RuleFor(p => p.Population)
            .GreaterThan(0).WithMessage("Every planet has a living being")
            .NotEmpty().WithMessage("You must tell how many habitants the planet has");

        RuleFor(p => p.Climate)
            .NotEmpty().WithMessage("Every planet has a climate");
    }
}
