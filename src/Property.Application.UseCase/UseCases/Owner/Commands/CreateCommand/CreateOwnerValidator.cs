using FluentValidation;

namespace Property.Application.UseCase.UseCases.Owner.Commands.CreateCommand
{
    public class CreateOwnerValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser Vacio");
        }

    }
}
